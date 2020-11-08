using System;

namespace THN.Infrastructure.Common.ExtentionHelpers
{
    public static class DateTimeExtentionHelper
    {
        public static DateTime UnixTimeStampToDate(this double unixTimeStamp, DateTimeKind dateTimeKind)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, dateTimeKind);
            dateTime = dateTime.AddSeconds(unixTimeStamp);
            return dateTime;
        }
    }
}
