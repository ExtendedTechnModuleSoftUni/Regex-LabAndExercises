namespace _01L.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            var text = "Petar Petrov, Ignat Stoyanov, Vladimir Stoimenov, ivan ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Ivan IvAnov, Ivan	Ivanov, Ivan Ivanov, Venci Sarov, Mario Ivanov";

            var pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0]);
            }
        }
    }
}
