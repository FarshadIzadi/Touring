using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class ApplicationRoles : IdentityRole
    {
        public ApplicationRoles()
        {
        }

        public ApplicationRoles(string roleName) : base(roleName)
        {
        }
    }
}
