using System;
using System.Collections.Generic;

namespace Domain.Utils
{
    public class PagedList<T> where T : class
    {
        public Int32 Page { get; private set; }
        public Int32 Size { get; private set; }
        public ICollection<T> Content { get; private set; }
        public Int32 Total { get; private set; }

        private PagedList()
        {
        }

        public PagedList(List<T> content, Int32 page, Int32 size)
        {
            Total = content.Count;
            Content = content;
            Page = page;
            Size = size;
        }

    }
}