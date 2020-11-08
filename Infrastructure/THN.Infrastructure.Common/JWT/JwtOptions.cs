using System;
using System.Collections.Generic;
using System.Text;

namespace THN.Infrastructure.Common.JWT
{
    public class JwtOptions
    {
        public string Secret { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
