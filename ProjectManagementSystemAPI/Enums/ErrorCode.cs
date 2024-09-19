namespace ProjectManagementSystemAPI.Enums
{
    public enum ErrorCode
    {
        None = 0,
        UnKnown = 1,

        UserNotFound = 1000,

        ProjectNotFound = 2000,
        NotValidProjectID = 2001,
        NotValidProjectData = 2002,

        NotValidDates = 2002
    }
}
