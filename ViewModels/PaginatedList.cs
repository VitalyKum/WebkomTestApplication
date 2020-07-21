using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webkom.Models;
using Webkom.ViewModels.Switches;

namespace Webkom.Stuff
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int PageCount { get; private set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public SelectList PageSizeOptions { get; private set; }
        public bool ExtendedFilterOn { get; set; }
        public SwitchFilter Filter { get; set; }
      
        private PaginatedList(List<T> items,  int count, int pageIndex, int pageSize)
        {           
            PageIndex = pageIndex;
            PageSize = pageSize;
            if(pageSize > 0)
                PageCount = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
            CreatePageSizeOptionsList();
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < PageCount;
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            if(pageSize == -1)
                pageSize = count;
            var items = new List<T>();
            if (count > 0)
                items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
        private void CreatePageSizeOptionsList()
        {
            List<SelectListItem> list = new List<SelectListItem>
            { 
                new SelectListItem{ Text="Все", Value = "-1"},
                new SelectListItem{ Text="по 5", Value="5" },
                new SelectListItem{ Text="по 10", Value="10"},
                new SelectListItem{ Text="по 20", Value="20"}
            };
            PageSizeOptions = new SelectList(list, "Value", "Text", PageSize);
        }
    }
}
