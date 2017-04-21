namespace _04ME.HappinessIndex
{
    using System;
    using System.Text.RegularExpressions;

    public class HappinessIndex
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var happinessEmoticonsPattern = @"(:\)|:D|;\)|:\*|:\]|;\]|:\}|;\}|\(:|\*:|c:|\[:|\[;)";
            var sadEmoticonsPattern = @"(:\(|D:|;\(|:\[|;\[|:\{|;\{|\):|:c|\]:|\];)";

            var happinessRegex = new Regex(happinessEmoticonsPattern);
            var sadRegex = new Regex(sadEmoticonsPattern);

            var happinessMatches = happinessRegex.Matches(inputLine);
            var sadMatches = sadRegex.Matches(inputLine);

            double happinessIndex = happinessMatches.Count / (double)sadMatches.Count;
            string emoticon = GetEmoticon(happinessIndex);

            Console.WriteLine($"Happiness index: {happinessIndex:f2} {emoticon}");
            Console.WriteLine($"[Happy count: {happinessMatches.Count}, Sad count: {sadMatches.Count}]");
        }

        static string GetEmoticon(double happinessIndex)
        {
            var emoticon = string.Empty;

            if (happinessIndex < 1)
            {
                emoticon = ":(";
            }
            else if (happinessIndex == 1)
            {
                emoticon = ":|";
            }
            else if (happinessIndex > 1 && happinessIndex < 2)
            {
                emoticon = ":)";
            }
            else
            {
                emoticon = ":D";
            }

            return emoticon;
        }
    }
}
