namespace _01ME.Cards
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Cards
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var pattern = @"(?<![0-9]{1})([2-9JQKA]|10)([SHDC])";

            var regex = new Regex(pattern);
            var matches = regex.Matches(inputLine);

            var cards = new List<string>();

            foreach (Match match in matches)
            {
                cards.Add(match.Groups[0].ToString());
            }

            if (cards.Count > 0)
            {
                Console.WriteLine(string.Join(", ", cards));

            }
        }
    }
}
