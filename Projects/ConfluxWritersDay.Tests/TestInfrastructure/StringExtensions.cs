namespace ConfluxWritersDay.Tests.TestInfrastructure
{
    public static class StringExtensions
    {
        public static string ToHtmlNamingConvention(this string name)
        {
            return name.Substring(0, 1).ToLower() + name.Substring(1);
        }
    }
}
