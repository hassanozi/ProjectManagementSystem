namespace ProjectManagementSystemAPI.Enums
{
    public enum ErrorCode
    {
        None = 0,
        UnKnown = 1,

        UserNotFound = 1000,
        NotValidUserID = 1001,
        NotValidRoleID = 1002,


        ProjectNotFound = 2000,
        NotValidProjectID = 2001,
        NotValidProjectData = 2002,

        NullName = 4004
    }
}
