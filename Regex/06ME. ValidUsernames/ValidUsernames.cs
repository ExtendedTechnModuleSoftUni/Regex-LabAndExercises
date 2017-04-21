namespace _06ME.ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split(new[] { '\\', '/', '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var userNamesValidation = new Regex(@"^[A-Za-z]\w{2,24}$");
            var validUserNames = new List<string>();
            var maxLength = int.MinValue;
            var firstString = string.Empty;
            var secondString = string.Empty;

            foreach (var word in inputLine)
            {
                var match = userNamesValidation.Match(word);

                if (match.Success)
                {
                    validUserNames.Add(word);
                }
            }

            for (int i = 0; i < validUserNames.Count - 1; i++)
            {
                var currentLength = validUserNames[i].Length + validUserNames[i + 1].Length;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    firstString = validUserNames[i];
                    secondString = validUserNames[i + 1];
                }
            }

            Console.WriteLine(firstString);
            Console.WriteLine(secondString);
        }
    }
}
