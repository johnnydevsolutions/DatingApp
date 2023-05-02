using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Extensions
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1; // default page number
        private int _pageSize = 10; // default page size
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; // if value is greater than max page size, set it to max page size, else set it to value
        }

        public string? CurrentUsername { get; set; }
        public string? Gender { get; set; }
        public int MinAge { get; set; } = 18; // default min age
        public int MaxAge { get; set; } = 100; // default max age
        public string OrderBy { get; set; } = "lastActive"; // default order by last active
    }
}
