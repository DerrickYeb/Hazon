using Core.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Models
{
    public class ApplicationRole : IdentityRole, IIdentityTenant
    {
        public string Description { get; set; }
        public string TenantKey { get; set; }

        public ApplicationRole()
        :base(){}

        public ApplicationRole(string roleName,string description, string tenantKey)
            :base(roleName)
        {
            Description = description;
            TenantKey = tenantKey;
            NormalizedName = roleName.ToUpper();
        }
    }
}
