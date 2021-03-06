using System;
using THN.Infrastructure.Common.ExtentionHelpers;
using Xunit;
using Xunit.Abstractions;

namespace THN.Infrashtructure.Common.XUnitTest
{
    public class StringExtentionHelper_UnitTest
    {
        private readonly ITestOutputHelper _output;

        public StringExtentionHelper_UnitTest(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
        }

        [Fact]
        public void IsValidEmail_IsEmail()
        {
            string email = "NamTH22@fpt.com.vn";
            var result = email.IsValidEmail();
            Assert.True(result);
        }

        [Fact]
        public void ClearHtml_ReturnNotHtml()
        {
            string textInput = "<span>NamTH22<span>";
            var result = textInput.ClearHtml();

            Assert.Equal("NamTH22", result);
        }

        [Fact]
        public void ConvertWhiteSpacesToSingleSpace_Test()
        {
            string textInput = "  NamTH22    ";
            var result = textInput.ConvertWhiteSpacesToSingleSpace();

            Assert.Equal(" NamTH22 ", result);
        }

        [Fact]
        public void RemoveSpecialChars_Test()
        {

            string textInput = "@NamTH22";
            var result = textInput.RemoveSpecialChars();

            Assert.Equal("NamTH22", result);
        }

        [Fact]
        public void ChangeCharVietnameseToNormal_Test()
        {
            string textInput = "Trịnh Hùng Nam";
            var result = textInput.ChangeCharVietnameseToNormal();

            Assert.Equal("Trinh Hung Nam", result);
        }

        [Fact]
        public void GetFirst_Test()
        {
            string textInput = "Trịnh Hùng Nam";
            var result = textInput.GetFirst(2);

            Assert.Equal("Tr", result);
        }


        [Fact]
        public void GetLast_Test()
        {
            string textInput = "Trịnh Hùng Nam";
            var result = textInput.GetLast(2);

            Assert.Equal("am", result);
        }

        [Fact]
        public void IsNumberic_Number()
        {
            string numberText = "123456";
            var result = numberText.IsNumberic();
            Assert.True(result);
        }


        [Fact]
        public void IsNumberic_String()
        {
            string numberText = "123456HH";
            var result = numberText.IsNumberic();
            Assert.False(result);
        }

        [Fact]
        public void ToInt_Test()
        {
            string numberText = "123456";
            var result = numberText.ToInt();
            Assert.Equal(123456, result);
        }

        [Fact]
        public void ToFloat_Test()
        {
            string numberText = "12.345";
            var result = numberText.ToFloat();
            Assert.Equal(12.345, Math.Round(result, 3));
        }

        [Fact]
        public void UppercaseFirst_Test()
        {
            string textInput = "nam";
            var result = textInput.UppercaseFirst();
            _output.WriteLine("Result: {0}", result);
            Assert.Equal("Nam", result);
        }
    }
}
