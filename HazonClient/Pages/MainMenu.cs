namespace HazonClient.Pages
{
    public static class MainMenu
    {
        public static class Lead
        {
            public static string PageName = "Lead";
            public static string RoleName = "Lead";
            public static string Path = "Business/Index";
            public const string ControllerName = "Business";
            public const string ActionName = "Index";
        }
        public static class UnReleased
        {
            public const string PageName = "UnReleased";
            public const string RoleName = "UnReleased";
            public const string Path = "Business/UnReleased";
            public const string ControllerName = "Business";
            public const string ActionName = "UnReleased";
        }
        public static class Released
        {
            public const string PageName = "Released";
            public const string RoleName = "Released";
            public const string Path = "Business/Released";
            public const string ControllerName = "Business";
            public const string ActionName = "Released";
        }
        public static class Email
        {
            public const string PageName = "Email";
            public const string RoleName = "Email";
            public const string Path = "Notification/Email";
            public const string ControllerName = "Notification";
            public const string ActionName = "Email";
        }
        public static class Sms
        {
            public const string PageName = "Sms";
            public const string RoleName = "Sms";
            public const string Path = "Notification/Sms";
            public const string ControllerName = "Notification";
            public const string ActionName = "Sms";
        }
        public static class WhatsApp
        {
            public const string PageName = "WhatsApp";
            public const string RoleName = "WhatsApp";
            public const string Path = "Notification/WhatsApp";
            public const string ControllerName = "Notification";
            public const string ActionName = "WhatsApp";
        }
        public static class Inbox
        {
            public const string PageName = "Inbox";
            public const string RoleName = "Inbox";
            public const string Path = "Notification/Inbox";
            public const string ControllerName = "Notification";
            public const string ActionName = "Inbox";
        }


        public static class Dashboard
        {
            public const string PageName = "Dashboard";
            public const string RoleName = "Dashboard";
            public const string Path = "/Dashboard/Index";
            public const string ControllerName = "Dashboard";
            public const string ActionName = "Index";
        }

        public static class Login
        {
            public const string PageName = "Login";
            public const string RoleName = "Account";
            public const string Path = "Account/Login";
            public const string ControllerName = "Account";
            public const string ActionName = "Login";
        }
        public static class ForgotPassword
        {
            public const string PageName = "Forgot Password";
            public const string RoleName = "ForgotPassword";
            public const string Path = "/Account/ForgotPassword";
            public const string ControllerName = "Account";
            public const string ActionName = "ForgotPassword";
        }
    }
}
