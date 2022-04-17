using Greenwich.CommonServices;
using Greenwich.DataPersistence;
using Greenwich.EntityFramework;
using Greenwich.Models;
using Greenwich.Models.Settings;
using Greenwich.WebService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Use configuration
ConfigurationManager configuration = builder.Configuration;

#region Jwt Settings

var jwtOptions = new JwtOptions();
var jwtSection = configuration.GetSection("jwt");
jwtSection.Bind(jwtOptions);
builder.Services.Configure<JwtOptions>(jwtSection);
builder.Services.AddSingleton<IJwtOptions, JwtOptions>();

#endregion

#region SendGrid Settings

builder.Services.Configure<SendGridSetting>(configuration.GetSection("SendGrid"));
builder.Services.AddSingleton<ISendGridSetting, SendGridSetting>();

#endregion

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataPersistence();
builder.Services.AddDbContext<GEWDbcontext>(options => options.UseSqlServer(configuration.GetConnectionString("GEWConnection")));
builder.Services.AddCommonServices();
builder.Services.AddWebServices();

// CORS Process
builder.Services.AddCors();

// Add Authentication
builder.Services.AddAuthentication().AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidIssuer = jwtOptions.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
    };
});

// Config authentication for Swagger
// Middleware
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Greenwich.Enterprise.Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "JWT Authorization",
        Description = "JWT Authorization header using the Bearer scheme.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            System.Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS Process
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
