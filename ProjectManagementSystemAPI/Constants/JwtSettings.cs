namespace ProjectManagementSystemAPI.Constants
{
    public static class JwtSettings
    {
        public static string Key { get; set; } = "ABYREQ$EWIEOUSLHT#@!WPIDTREFRSEE*&^%DHGFDREE";
        public static string Issuer { get; set; } = "UpSkilling";
        public static string Audience { get; set; } = "UpSkilling-Users";
        public static int DurationInMinutes { get; set; } = 60;
    }
}
