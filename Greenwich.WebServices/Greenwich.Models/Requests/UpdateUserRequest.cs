using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.Models.Requests
{
    public class UpdateUserRequest
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is Required")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "User Role is Required")]
        public int UserRoleId { get; set; }
        
        [Required(ErrorMessage = "Sites is Required")]
        public IEnumerable<int> SiteIds { get; set; }
    }
}
