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
            return date.Month switch
            {
                12 or 1 or 2 => Season.Winter,
                3 or 4 or 5 => Season.Spring,
                6 or 7 or 8 => Season.Summer,
                9 or 10 or 11 => Season.Autumn,
                _ => throw new ArgumentOutOfRangeException(nameof(date), "Invalid month")
            };
        }

        public static bool IsSummer(this DateTime date)
        {
            return date.GetSeason() == Season.Summer;
        }

        public static int DaysUntilNextSeason(this DateTime date) {
            var currentSeason = date.GetSeason();
            var nextSeasonStartMonth = currentSeason switch
            {
                Season.Winter => 3,
                Season.Spring => 6,
                Season.Summer => 9,
                Season.Autumn => 12,
                _ => throw new ArgumentOutOfRangeException(nameof(date), "Invalid season")
            };
            var nextSeasonStartDate = new DateTime(date.Year, nextSeasonStartMonth, 1);
            if (nextSeasonStartDate <= date)
            {
                nextSeasonStartDate = nextSeasonStartDate.AddYears(1);
            }
            return (nextSeasonStartDate - date).Days;
        }
    }
}
