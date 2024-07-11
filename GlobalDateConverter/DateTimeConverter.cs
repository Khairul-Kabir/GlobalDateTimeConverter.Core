using System.Globalization;
using System.Text;

namespace GlobalDateConverter
{
    public class DateTimeConverter
    {
        public static string ConvertDateTime(DateTime dateTime, string cultureName)
        {
            CultureInfo culture = new CultureInfo(cultureName);
            Calendar calendar = culture.Calendar;

            // Get the calendar-specific date parts
            int day = calendar.GetDayOfMonth(dateTime);
            int month = calendar.GetMonth(dateTime);
            int year = calendar.GetYear(dateTime);

            // Get the culture-specific month name
            string monthName = culture.DateTimeFormat.GetMonthName(month);

            // Convert the parts to culture-specific numerals if necessary
            string dayString = ConvertToCultureSpecificDigits(day, culture);
            string monthString = monthName;
            string yearString = ConvertToCultureSpecificDigits(year, culture);

            // Format the time part and convert it to culture-specific numerals
            string timeString = dateTime.ToString("HH:mm:ss", culture);
            string localizedTimeString = ConvertToCultureSpecificDigits(timeString, culture);

            return $"{dayString} {monthString}, {yearString} {localizedTimeString}";
        }

        private static string ConvertToCultureSpecificDigits(int number, CultureInfo culture)
        {
            if (culture.Name == "hi-IN")
            {
                return ConvertToHindiDigits(number);
            }

            string[] nativeDigits = culture.NumberFormat.NativeDigits;
            StringBuilder result = new StringBuilder();

            foreach (char digit in number.ToString())
            {
                if (char.IsDigit(digit))
                {
                    result.Append(nativeDigits[digit - '0']);
                }
                else
                {
                    result.Append(digit);
                }
            }

            return result.ToString();
        }

        private static string ConvertToCultureSpecificDigits(string time, CultureInfo culture)
        {
            if (culture.Name == "hi-IN")
            {
                return ConvertToHindiDigits(time);
            }

            string[] nativeDigits = culture.NumberFormat.NativeDigits;
            StringBuilder result = new StringBuilder();

            foreach (char character in time)
            {
                if (char.IsDigit(character))
                {
                    result.Append(nativeDigits[character - '0']);
                }
                else
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }

        private static string ConvertToHindiDigits(int number)
        {
            string[] hindiDigits = { "०", "१", "२", "३", "४", "५", "६", "७", "८", "९" };
            StringBuilder result = new StringBuilder();

            foreach (char digit in number.ToString())
            {
                result.Append(hindiDigits[digit - '0']);
            }

            return result.ToString();
        }

        private static string ConvertToHindiDigits(string time)
        {
            string[] hindiDigits = { "०", "१", "२", "३", "४", "५", "६", "७", "८", "९" };
            StringBuilder result = new StringBuilder();

            foreach (char character in time)
            {
                if (char.IsDigit(character))
                {
                    result.Append(hindiDigits[character - '0']);
                }
                else
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }
    }
}
