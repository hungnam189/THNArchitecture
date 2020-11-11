using System;
using THN.Infrastructure.Common.ExtentionHelpers;
using Xunit;
using Xunit.Abstractions;

namespace THN.Infrashtructure.Common.XUnitTest
{
    public class DateTimeExtentionHelper_UnitTest
    {
        private readonly ITestOutputHelper _output;

        public DateTimeExtentionHelper_UnitTest(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
        }


        [Fact]
        public void UnixTimeStampToDate_Test()
        {
            double textInput = 1604388126;
            var result = textInput.UnixTimeStampToDate(DateTimeKind.Utc);
            _output.WriteLine("Result: {0}", result);
            Assert.False(result == null);
        }
    }
}
