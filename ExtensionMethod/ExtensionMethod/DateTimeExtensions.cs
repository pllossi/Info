namespace ExtensionMethod
{
    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
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
                return Season.Spring;
            if (date >= summerStart && date < autumnStart)
                return Season.Summer;
            if (date >= autumnStart && date < winterStart)
                return Season.Autumn;

            var nextYearWinterStart = new DateTime(year + 1, 3, 21);
            if (date >= winterStart || date < nextYearWinterStart)
                return Season.Winter;

            throw new ArgumentOutOfRangeException(nameof(date), "Invalid date");
        }

        public static bool IsSummer(this DateTime date)
        {
            return date.GetSeason() == Season.Summer;
        }

        public static int DaysUtilNextSeason(this DateTime date)
        {
            var year = date.Year;
            DateTime nextSeasonStart;
            switch (date.GetSeason())
            {
                case Season.Spring:
                    nextSeasonStart = new DateTime(year, 6, 21);
                    break;
                case Season.Summer:
                    nextSeasonStart = new DateTime(year, 9, 21);
                    break;
                case Season.Autumn:
                    nextSeasonStart = new DateTime(year, 12, 21);
                    break;
                case Season.Winter:
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
