using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace THN.Infrastructure.Common.ExtentionHelpers
{
    public static class StringExtentionHelper
    {
        public static bool IsValidEmail(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            var matched = Regex.Match(value.Trim(), @"\w+([-+.])*@\w+([-.])");
            return matched.Success;
        }
    }
}
