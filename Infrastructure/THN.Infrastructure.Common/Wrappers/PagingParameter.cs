using System;
using System.Collections.Generic;
using System.Text;

namespace THN.Infrastructure.Common.Wrappers
{
    public class PagingParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }
    }
}
