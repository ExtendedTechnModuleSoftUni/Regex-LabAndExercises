namespace _01LGE.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = @"(?: )([A-Za-z0-9]+(\.?|-?|_)[A-Za-z0-9]+@[A-Za-z]+(-?\.?)[A-Za-z]+\.[A-za-z]+)";
            var regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }
        }
    }
}
