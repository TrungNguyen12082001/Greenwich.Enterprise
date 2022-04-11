using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.Models.Responses
{
    public class UserListResponse
    {
        public IEnumerable<ShortUserResponse> UserList { get; set; }
    }


}
