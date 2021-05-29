using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Model
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int TotalPage
        {
            get
            {
                var temp = (double)Total / (double)PageSize;
                var p = Math.Ceiling(temp);
                return (int)p;
            }
        }
        public int Total { get; set; }
        public int PageSize { get; set; } = 10;
        public int Skip()
        {
            if (this.CurrentPage <= 1)
            {
                return 0;
            }
            else
            {
                return (CurrentPage - 1) * PageSize;
            }
        }
    }
    public class Pagination<T> : Pagination
    {
        public List<T> Data { get; set; }
    }
}
