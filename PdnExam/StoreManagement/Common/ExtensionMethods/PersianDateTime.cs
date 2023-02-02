using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement
{
    public static class DateTimeExtensionMethos
    {
        public static string ToPersianDateTimeString(this DateTime dateTime, bool onlyTwoDigitsOfYear = false,
            bool persianMonth = false, bool persianDayOfWeek = false, bool includeTime = false, bool useAmPm = false,
            bool useSlash = true)
        {
            var persianCalendar = new PersianCalendar();

            var year = onlyTwoDigitsOfYear ?
                persianCalendar.GetYear(dateTime).ToString().Substring(2) :
                persianCalendar.GetYear(dateTime).ToString();

            var month = persianMonth ?
                PersianMonthName(persianCalendar.GetMonth(dateTime)) :
                persianCalendar.GetMonth(dateTime).ToString();

            var day = persianDayOfWeek ?
                DayOfWeekPersianName(persianCalendar.GetDayOfWeek(dateTime)) :
                persianCalendar.GetDayOfMonth(dateTime).ToString();


            var result = useSlash ?
                $"{year}/{month}/{day}" :
                $"{day} {month} {year}";

            if (!includeTime)
            {
                return result;
            }

            var hour = persianCalendar.GetHour(dateTime);
            var hourStr = hour.ToString();
            var amPmWord = "صبح";
            if (useAmPm && hour > 13)
            {
                hour = hour - 12;
                amPmWord = "بعد از ظهر";
            }

            var minute = persianCalendar.GetMinute(dateTime).ToString();
            if (minute.Length == 1)
            {
                minute = $"0{minute}";
            }

            if (useAmPm)
            {
                return $"{result} - ساعت {hourStr}:{minute} {amPmWord}";
            }

            return $"{result} - ساعت {hourStr}:{minute}";
        }

        public static string DayOfWeekPersianName(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "يکشنبه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Tuesday: return "سه‏ شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Thursday: return "پنجشنبه";
                case DayOfWeek.Friday: return "جمعه";
                default: return "";
            }
        }

        public static string PersianMonthName(int persianMonth)
        {
            switch (persianMonth)
            {
                case 1: return "فررودين";
                case 2: return "ارديبهشت";
                case 3: return "خرداد";
                case 4: return "تير‏";
                case 5: return "مرداد";
                case 6: return "شهريور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دي";
                case 11: return "بهمن";
                case 12: return "اسفند";
                default: return "";
            }
        }
    }
}
