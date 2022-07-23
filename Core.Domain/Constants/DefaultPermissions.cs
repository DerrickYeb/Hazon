using System.Collections.Generic;

namespace Core.Domain.Constants
{
    public static class DefaultPermissions
    {
        public static List<string> Basics => new List<string>()
        {
            PermissionConstants.Customers.Search,
            PermissionConstants.UnderwritingPolicies.View,
            PermissionConstants.UnderwritingPolicies.Search,
            PermissionConstants.Customers.View
        };
    }
}