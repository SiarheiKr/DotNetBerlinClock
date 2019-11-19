using System;
using System.Text.RegularExpressions;

namespace BerlinClock.Helpers
{
    internal static class ExtendedTimeParser
    {

        internal static bool TryParse(string input, out TimeSpan timeSpan)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            //special case to parse 24:00:00 time format 
            if (Regex.IsMatch(input, @"^\s*24:[0]{1,2}(:[0]{1,2})?\s*$", RegexOptions.Singleline))
            {
                timeSpan = TimeSpan.FromDays(1);
                return true;
            }

            bool isSucceeded = DateTime.TryParse(input, out DateTime dateAndTime);

            timeSpan = dateAndTime.TimeOfDay;

            return isSucceeded;
        }
    }
}
