namespace ProjectManagementSystemAPI.ViewModels
{
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }

        public static ResponseViewModel Sucess(dynamic data, string message = "Success Operation")
        {
            return new ResponseViewModel
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }

        public static ResponseViewModel Faliure(string message = "Invalid Operation")
        {
            return new ResponseViewModel
            {
                IsSuccess = false,
                Data = default,
                Message = message,
            };
        }
    }
}
