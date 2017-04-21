namespace _02E.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var pattern = @"\+359(\s|-)2\1\d{3}\1\d{4}\b";

            var regex = new Regex(pattern);

            Console.WriteLine(regex.IsMatch(inputLine));
            var matches = regex.Matches(inputLine);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0]);
            }
        }
    }
}
