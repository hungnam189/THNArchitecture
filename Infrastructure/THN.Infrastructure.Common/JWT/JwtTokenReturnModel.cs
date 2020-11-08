using System;
using System.Collections.Generic;
using System.Text;

namespace THN.Infrastructure.Common.JWT
{
    public class JwtTokenReturnModel
    {
        /// <summary>
        /// Token(string)
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token timeout (minutes)
        /// </summary>
        public int TokenTimeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpirationDate { get; set; }

    }
}
