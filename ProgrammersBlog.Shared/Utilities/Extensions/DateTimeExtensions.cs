namespace ProgrammersBlog.Shared.Utilities.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FullDateAndTimeStringWithUnderscore(this DateTime dateTime)
        {
            return $"{dateTime.Millisecond}_{dateTime.Second}_{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Month}_{dateTime.Year}";
            //resmin  adını tarih yıl gibi ekleyerek alt tire ile ayırarak yapıyor.
            //MehmetGuler_235_47_15_18_7_4_2025
        }
    }
}
