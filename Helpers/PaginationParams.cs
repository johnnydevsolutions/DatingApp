namespace back.Helpers
{
    public class PaginationParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1; // default page number
        private int _pageSize = 10; // default page size
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; // if value is greater than max page size, set it to max page size, else set it to value
        }
    }
}