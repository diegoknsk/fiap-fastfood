using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Application.Models.Common
{
    public class PagedResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public PagedResponse(PagedList<T> paged)
        {
            CurrentPage = paged.CurrentPage;
            TotalPages = paged.TotalPages;
            PageSize = paged.PageSize;
            TotalCount = paged.TotalCount;
            HasPrevious = paged.HasPrevious;
            HasNext = paged.HasNext;
            Items = paged;
        }
    }
}
