using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace back.Helpers
{
    public class PageList<T> : List<T>
    {
        public PageList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize); 
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public int CurrentPage {get; set;}
        public int TotalPages {get; set;}
        public int PageSize {get; set;}
        public int TotalCount {get; set;}

        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            // CountAsync() is an extension method from Microsoft.EntityFrameworkCore
            var count = await source.CountAsync();
            // Skip() is an extension method from Microsoft.EntityFrameworkCore
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            // return new PageList<T>(items, count, pageNumber, pageSize);
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}