namespace _02LGE.ExtractSentencesByKeyword
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractSentencesByKeyword
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var textLines = Console.ReadLine().Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var pattern = @".+(\W)" + word + @"(\W).+";
            var regex = new Regex(pattern);

            foreach (var line in textLines)
            {
                var currentLine = line.Trim();
                var match = regex.Match(currentLine);
                var isMatch = regex.IsMatch(currentLine);

                if (isMatch)
                {
                    Console.WriteLine(match.Groups[0]);
                }
            }
        }
    }
}
