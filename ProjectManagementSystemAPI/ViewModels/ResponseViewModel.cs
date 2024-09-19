using ProjectManagementSystemAPI.Enums;

namespace ProjectManagementSystemAPI.ViewModels
{
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }


        public static ResponseViewModel Success(dynamic data, string message = "")
        {
            return new ResponseViewModel
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                ErrorCode = ErrorCode.None,
            };
        }

        public static ResponseViewModel Faliure( string message, ErrorCode errorCode = ErrorCode.UnKnown)
        {
            return new ResponseViewModel
            {
                IsSuccess = false,
                Data = default,
                Message = message,
                ErrorCode = errorCode,
            };
        }
    }
}
