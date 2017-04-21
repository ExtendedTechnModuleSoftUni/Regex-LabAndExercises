namespace _03ME.WordEncounter
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class WordEncounter
    {
        public static void Main()
        {
            var filter = Console.ReadLine();
            var filterChar = filter[0];
            var filterDigit = int.Parse(filter[1].ToString());
            var escapedCharacters = 
                new List<char> { '.', '^', '$', '*', '+', '-', '?', '(', ')', '[', ']', '{', '}', '\\', '|' };

            var sentense = Console.ReadLine();
            var wordsValidationPattern = string.Empty;
            var validationsPattern = @"^[A-Z].+(\.|!|\?)$";

            if (!escapedCharacters.Contains(filterChar))
            {
                wordsValidationPattern = @"\b[^\s]*" + filterChar.ToString() + @"[^\s]*\b";
            }
            else
            {
                wordsValidationPattern = @"\b[^\s]*" + "\\" + filterChar.ToString() + @"[^\s]*\b";
            }

            var validationRegex = new Regex(validationsPattern);
            var validWordsRegex = new Regex(wordsValidationPattern);
            var validWord = new List<string>();

            while (sentense != "end")
            {
                var isMatch = validationRegex.IsMatch(sentense);

                if (isMatch)
                {
                    var wordMatches = validWordsRegex.Matches(sentense);

                    foreach (Match word in wordMatches)
                    {
                        int index = word.ToString().IndexOf(filterChar);
                        int counter = 0;

                        while (index != -1)
                        {
                            counter++;
                            index = word.ToString().IndexOf(filterChar, index + 1);
                        }

                        if (counter >= filterDigit)
                        {
                            validWord.Add(word.ToString());
                        }
                    }
                }

                sentense = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", validWord));
        }
    }
}