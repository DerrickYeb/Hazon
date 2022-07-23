using System.ComponentModel;

namespace Core.Domain.Constants
{
    public class PermissionConstants
    {
        [DisplayName("Identity")]
        [Description("Identity Permissions")]
        public static class Identity
        {
            public const string Register = "Permissions.Identity.Register";
        }

        [DisplayName("Roles")]
        [Description("Roles Permissions")]
        public static class Roles
        {
            public const string View = "Permissions.Roles.View";
            public const string ListAll = "Permissions.Roles.ViewAll";
            public const string Register = "Permissions.Roles.Register";
            public const string Update = "Permissions.Roles.Update";
            public const string Remove = "Permissions.Roles.Remove";
        }

        [DisplayName("Customers")]
        [Description("Customers Permissions")]
        public static class Customers
        {
            public const string View = "Permissions.Customers.View";
            public const string Search = "Permissions.Customers.Search";
            public const string Register = "Permissions.Customers.Register";
            public const string Update = "Permissions.Customers.Update";
            public const string Remove = "Permissions.Customers.Remove";
        }

        [DisplayName("UnderwritingPolicies")]
        [Description("UnderwritingPolicies Permissions")]
        public static class UnderwritingPolicies
        {
            public const string View = "Permissions.UnderwritingPolicies.View";
            public const string Search = "Permissions.UnderwritingPolicies.Search";
            public const string Create = "Permissions.UnderwritingPolicies.Register";
            public const string Update = "Permissions.UnderwritingPolicies.Update";
            public const string Remove = "Permissions.UnderwritingPolicies.Remove";
        }

        [DisplayName("Role Claims")]
        [Description("Role Claims Permissions")]
        public static class RoleClaims
        {
            public const string View = "Permissions.RoleClaims.View";
            public const string Create = "Permissions.RoleClaims.Create";
            public const string Edit = "Permissions.RoleClaims.Edit";
            public const string Delete = "Permissions.RoleClaims.Delete";
            public const string Search = "Permissions.RoleClaims.Search";
        }
    }
}