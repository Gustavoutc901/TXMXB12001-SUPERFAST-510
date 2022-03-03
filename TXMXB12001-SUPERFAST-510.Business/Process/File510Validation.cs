using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TXMXB12001_SUPERFAST_510
{
    partial class File510Process
    {
        static Regex regexOnlyNumbers = new Regex(@"^\d$");

        private static string ValidationOnlyNumbers(string value, bool isRequired)
        {
            if (!isRequired && string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            if (regexOnlyNumbers.IsMatch(value))
            {
                return value;
            }
            return null;
        }

        private static long? ValidationLong(string value, bool isRequired)
        {
            if (!long.TryParse(value, out long returnValue))
            {
                if (isRequired)
                {
                    _existError = true;
                    return 0;
                }
                return null;
            }
            return returnValue;
        }
        private static TimeSpan? ValidationTime(string value, bool isRequired)
        {

            if (!TimeSpan.TryParseExact(value, @"hmmss", CultureInfo.InvariantCulture, out TimeSpan returnValue))
            {
                if (isRequired)
                {
                    _existError = true;
                    return TimeSpan.MinValue;
                }
                return null;
            }
            return returnValue;
        }
        private static decimal? ValidationDecimal(string value, int integers, int decimals, bool isRequired)
        {

            if (!decimal.TryParse($"{value.ToString()[..integers]}.{value.ToString()[^decimals..]}"
                                            , out decimal returnValue))
            {
                if (isRequired)
                {
                    _existError = true;
                    return 0;
                }
                return null;
            }
            return returnValue;
        }
        private static DateTime? ValidationDate(string value, bool isRequired)
        {
            if (!DateTime.TryParseExact(value, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime returnValue))
            {
                if (isRequired)
                {
                    _existError = true;
                    return DateTime.MinValue;
                }
                return null;
            }
            return returnValue;
        }
        private static string ValidationContains(string value, string[] validValues, bool defaultValueIsWhiteSpace)
        {
            if (defaultValueIsWhiteSpace && string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            if (string.IsNullOrWhiteSpace(value) && !validValues.ToList().Any(t => t == value.Trim()))
            {
                _existError = true;
            }
            return !_existError ? value : string.Empty;
        }
        private static long ValidationContainsLong(string value, long[] validValues)
        {
            if (long.TryParse(value, out long returnValue))
            {
                if (validValues.ToList().Any(t => t == returnValue))
                {
                    return returnValue;
                }
            }
            _existError = true;
            return 0;
        }
        private static string ValidationRequirement(string value, bool defaultValueIsWhiteSpace)
        {
            if (defaultValueIsWhiteSpace && string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                _existError = true;
                return null;
            }
            return value.Trim();

        }
    }
}
