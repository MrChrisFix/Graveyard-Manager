namespace GraveyardManager.Utils
{
    public class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public static Date FromDateTime(DateTime dt)
        {
            Date date = new()
            {
                Year = dt.Year,
                Month = dt.Month,
                Day = dt.Day
            };
            return date;
        }

        public static DateOnly ToDateTime(Date date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }
    }
}
