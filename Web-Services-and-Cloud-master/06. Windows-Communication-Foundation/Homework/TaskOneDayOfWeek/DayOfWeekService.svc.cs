namespace TaskOneDayOfWeek
{
    using System;

    public class DayOfWeekService : IDayOfWeekService
    {
        public string GetDayName(DateTime time)
        {
            switch (time.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Понеделник";
                case DayOfWeek.Tuesday:
                    return "Вторник";
                case DayOfWeek.Wednesday:
                    return "Сряда";
                case DayOfWeek.Thursday:
                    return "Четвъртък";
                case DayOfWeek.Friday:
                    return "Петък";
                case DayOfWeek.Saturday:
                    return "Събота";
                case DayOfWeek.Sunday:
                    return "Неделя";
                default:
                    return "Not support date";
            }
        }
    }
}
