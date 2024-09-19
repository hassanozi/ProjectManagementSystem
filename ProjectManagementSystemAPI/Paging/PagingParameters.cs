namespace ProjectManagementSystemAPI.Paging
{
    public class PagingParameters
    {
        public int PageNumber { get; set; } = 1;

        const int MaxSize = 50;

        private int _PageSize;

        public int PageSize
        {
            get { return _PageSize; }
            set 
            {
                _PageSize = (value > MaxSize) ? MaxSize : value;
            }
        }

    }
}
