using System;
using System.Collections.Generic;
using System.Text;

namespace THN.Infrastructure.Common.Wrappers
{
    public abstract class PagedResponse<T> : Response<T>
    {
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalRecords = 0;
            this.TotalPages = 0;
            this.Message = string.Empty;
            this.Succeeded = true;
            this.Errors = null;
        }

        public PagedResponse(T data, int totalRecords, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalRecords = totalRecords;
            this.TotalPages = totalRecords > 0 ? totalRecords / pageSize : 0;
            this.Message = string.Empty;
            this.Succeeded = true;
            this.Errors = null;
        }


        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages { get; set; }
    }
}
