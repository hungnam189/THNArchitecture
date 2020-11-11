using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace THN.Infrastructure.Common.ExtentionHelpers
{
    public static class StringExtentionHelper
    {
        #region StringExtentions
        /// <summary>
        /// Check Email
        /// </summary>
        /// <param name="strEmail">string input</param>
        /// <returns>true/false</returns>
        public static bool IsValidEmail(this string strEmail)
        {
            if (string.IsNullOrEmpty(strEmail))
                return false;

            var matched = Regex.Match(strEmail.Trim(), @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            return matched.Success;
        }


        /// <summary>
        /// Clear tag html
        /// </summary>
        /// <param name="strInput">string input</param>
        /// <returns>
        /// Ex: <span>Example</span> => Example
        /// </returns>
        public static string ClearHtml(this string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
                return string.Empty;
            strInput = HttpUtility.HtmlDecode(strInput);
            return Regex.Replace(strInput, @"<.[^>]*>", string.Empty);
        }

        /// <summary>
        /// Convert multi whit spaces to single white space
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns>
        /// Ex: Hahahaha       hehehe => Hahahaha hehehe
        /// </returns>
        public static string ConvertWhiteSpacesToSingleSpace(this string strInput)
        {
            return Regex.Replace(strInput, @"\s+", " ");
        }

        /// <summary>
        /// Remove white space and replace multi white space to single space
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string TrimAndReduce(this string strInput)
        {
            return ConvertWhiteSpacesToSingleSpace(strInput).Trim();
        }


        /// <summary>
        /// Remove special character
        /// {",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]"}
        /// Use: [A-z, 0-9]
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string RemoveSpecialChars(this string strInput)
        {
            return Regex.Replace(strInput, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }


        /// <summary>
        /// Change Vietnamese to normal; 
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string ChangeCharVietnameseToNormal(this string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
                return string.Empty;
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = strInput.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty);
        }


        /// <summary>
        /// Get first characters 
        /// </summary>
        /// <param name="strInput">string input</param>
        /// <param name="howMany">character number</param>
        /// <returns></returns>
        public static string GetFirst(this string strInput, int howMany)
        {
            if (string.IsNullOrEmpty(strInput))
                return string.Empty;
            var value = strInput.Trim();
            return howMany >= strInput.Length ? value : strInput.Substring(0, howMany);
        }

        /// <summary>
        /// Get last characters
        /// </summary>
        /// <param name="strInput">string input</param>
        /// <param name="howMany">characters number</param>
        /// <returns></returns>
        public static string GetLast(this string strInput, int howMany)
        {
            if (string.IsNullOrEmpty(strInput))
                return string.Empty;
            var value = strInput.Trim();
            return howMany >= strInput.Length ? value : strInput.Substring(strInput.Length - howMany);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string UppercaseFirst(this string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
                return string.Empty;

            return char.ToUpper(strInput[0]) + strInput.Substring(1);
        }

        #endregion StringExtentions
        
        #region To Number
        /// <summary>
        /// Check string is numberic
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static bool IsNumberic(this string strInput)
        {
            string strTemp = strInput.TrimAndReduce();
            if (string.IsNullOrEmpty(strTemp))
                return false;

            if (int.TryParse(strInput, out _) == true)
                return true;
            if (decimal.TryParse(strInput, out _) == true)
                return true;
            if (double.TryParse(strInput, out _) == true)
                return true;
            return false;
        }

        /// <summary>
        /// Convert string to int
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="throwExceptionIfFailed"></param>
        /// <returns></returns>
        public static int ToInt(this string strInput, bool throwExceptionIfFailed = false)
        {
            var valid = int.TryParse(strInput, out int result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as int", strInput));
            return result;
        }

        /// <summary>
        /// Convert string to Float
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="throwExceptionIfFailed"></param>
        /// <returns></returns>
        public static float ToFloat(this string strInput, bool throwExceptionIfFailed = false)
        {
            var valid = float.TryParse(strInput, out float result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as float", strInput));
            return result;
        }

        /// <summary>
        /// Convert string to double
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="throwExceptionIfFailed"></param>
        /// <returns></returns>
        public static double ToDouble(this string strInput, bool throwExceptionIfFailed = false)
        {
            var valid = double.TryParse(strInput, out double result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as double", strInput));
            return result;
        }

        /// <summary>
        /// Convert string to decimal
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="throwExceptionIfFailed"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string strInput, bool throwExceptionIfFailed = false)
        {
            var valid = decimal.TryParse(strInput, out decimal result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as decimal", strInput));
            return result;
        }
        #endregion To Number
    }
}
