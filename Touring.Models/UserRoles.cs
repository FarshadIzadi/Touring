using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class UserRoles
    {
        public ApplicationUser user { get; set; }
        public IEnumerable<ApplicationUserRole> Roles { get; set; }
    }
}
