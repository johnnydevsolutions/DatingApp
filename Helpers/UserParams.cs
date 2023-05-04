using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Helpers;

namespace back.Extensions
{
    public class UserParams : PaginationParams
    {

        public string? CurrentUsername { get; set; }
        public string? Gender { get; set; }
        public int MinAge { get; set; } = 18; // default min age
        public int MaxAge { get; set; } = 100; // default max age
        public string OrderBy { get; set; } = "lastActive"; // default order by last active
    }
}
