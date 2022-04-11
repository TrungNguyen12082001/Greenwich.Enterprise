using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.Models.Requests
{
    public class CreateDepartmentRequest
    {
        [Required]
        public string DepartmentName { get; set; }
    }
}
