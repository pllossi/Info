namespace ExtensionMethod
{
    public enum Season
    {
        WINTER,
        SPRING,
        SUMMER,
        AUTUMN
    }
    public static class DateTimeExtensions
    {
        public static Season GetSeason(this DateTime date)
        {
            var year = date.Year;
            var springStart = new DateTime(year, 3, 21);
            var summerStart = new DateTime(year, 6, 21);
            var autumnStart = new DateTime(year, 9, 21);
            var winterStart = new DateTime(year, 12, 21);

            if (date >= springStart && date < summerStart)
                return Season.SPRING;
            if (date >= summerStart && date < autumnStart)
                return Season.SUMMER;
            if (date >= autumnStart && date < winterStart)
                return Season.AUTUMN;

            var nextYearWinterStart = new DateTime(year + 1, 3, 21);
            if (date >= winterStart || date < nextYearWinterStart)
                return Season.WINTER;

            throw new ArgumentOutOfRangeException(nameof(date), "Invalid date");
        }

        public static bool IsSummer(this DateTime date)
        {
            return date.GetSeason() == Season.SUMMER;
        }

        public static int DaysUtilNextSeason(this DateTime date)
        {
            var year = date.Year;
            DateTime nextSeasonStart;
            switch (date.GetSeason())
            {
                case Season.SPRING:
                    nextSeasonStart = new DateTime(year, 6, 21);
                    break;
                case Season.SUMMER:
                    nextSeasonStart = new DateTime(year, 9, 21);
                    break;
                case Season.AUTUMN:
                    nextSeasonStart = new DateTime(year, 12, 21);
                    break;
                case Season.WINTER:
                    if(date.Month == 12)
                        nextSeasonStart = new DateTime(year + 1, 3, 21);
                    else
                        nextSeasonStart = new DateTime(year, 3, 21);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return (nextSeasonStart - date).Days;
        }
    }
}
