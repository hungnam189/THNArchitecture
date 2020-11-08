using System;
using System.Collections.Generic;
using System.Text;

namespace THN.Infrastructure.Common.Wrappers
{
    public class PagingRequestParameter : PagingParameter
    {
        public PagingRequestParameter()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PagingRequestParameter(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 10 ? 10 : pageSize;
        }


    }
}
