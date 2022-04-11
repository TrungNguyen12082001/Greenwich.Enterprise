using Greenwich.WebService.IServices;
using Greenwich.WebService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Greenwich.WebService
{
    public static class WebServiceExtension
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubmissionService, SubmissionService>();
            services.AddScoped<IIdeaService, IdeaService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IReplyService, ReplyService>();
        }
    }
}
