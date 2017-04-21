namespace _03L.ReplaceTag
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceTag
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string pattern = @"<a.*?href=(.*)>(.*?)<\/a>";
                string replace = @"[URL href=$1]$2[/URL]";
                string replaced = Regex.Replace(inputLine, pattern, replace);

                Console.WriteLine(replaced);
                inputLine = Console.ReadLine();
            }
        }
    }
}
