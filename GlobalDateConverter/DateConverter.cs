using System.Globalization;
using System.Text;

namespace GlobalDateConverter
{
    public class DateConverter
    {
        public static string ConvertDate(DateTime date, string cultureName)
        {
            CultureInfo culture = new CultureInfo(cultureName);
            Calendar calendar = culture.Calendar;

            // Get the calendar-specific date parts
            int day = calendar.GetDayOfMonth(date);
            int month = calendar.GetMonth(date);
            int year = calendar.GetYear(date);

            // Get the culture-specific month name
            string monthName = culture.DateTimeFormat.GetMonthName(month);

            // Convert the parts to culture-specific numerals if necessary
            string dayString = ConvertToCultureSpecificDigits(day, culture);
            string monthString = monthName;
            string yearString = ConvertToCultureSpecificDigits(year, culture);

            return $"{dayString} {monthString}, {yearString}";
        }

        private static string ConvertToCultureSpecificDigits(int number, CultureInfo culture)
        {
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
    }
}
