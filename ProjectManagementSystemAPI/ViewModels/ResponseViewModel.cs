using ProjectManagementSystemAPI.Enums;

namespace ProjectManagementSystemAPI.ViewModels
{
    public class ResponseViewModel<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }


        public static ResponseViewModel<T> Success<T>(T data, string message = "")
        {
            return new ResponseViewModel<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                ErrorCode = ErrorCode.None,
            };
        }

        public static ResponseViewModel<T> Faliure(ErrorCode errorCode, string message)
        {
            return new ResponseViewModel<T>
            {
                IsSuccess = false,
                Data = default,
                Message = message,
                ErrorCode = errorCode,
            };
        }
    }
}
