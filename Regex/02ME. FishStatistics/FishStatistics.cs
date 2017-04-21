namespace _02ME.FishStatistics
{
    using System;
    using System.Text.RegularExpressions;

    public class FishDetails
    {
        public string tailType { get; set; }

        public string bodyType { get; set; }

        public string status { get; set; }

    }

    public class FishStatistics
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var pattern = @"(>*)<(\(+)('|-|x)>";

            var regex = new Regex(pattern);

            var matches = regex.Matches(inputLine);
            var isMatch = false;
            var fishCounter = 1;

            foreach (Match match in matches)
            {
                isMatch = true;
                var tailLength = match.Groups[1].Length;
                var bodyLength = match.Groups[2].Length;
                var status = match.Groups[3].ToString();
                var currentFish = new FishDetails();
                GetFishDetails(currentFish, tailLength, bodyLength, status);

                tailLength = tailLength * 2;
                bodyLength = bodyLength * 2;

                PrintCurrentFish(fishCounter, match, tailLength, bodyLength, currentFish);

                fishCounter++;
            }

            if (!isMatch)
            {
                Console.WriteLine("No fish found.");
            }
        }

        private static void PrintCurrentFish(int fishCounter, Match match, int tailLength, int bodyLength, FishDetails currentFish)
        {
            if (tailLength > 0)
            {
                Console.WriteLine($"Fish {fishCounter}: {match.Groups[0]}");
                Console.WriteLine($"  Tail type: { currentFish.tailType} ({ tailLength} cm)");
                Console.WriteLine($"  Body type: { currentFish.bodyType} ({ bodyLength} cm)");
                Console.WriteLine($"  Status: { currentFish.status}");
            }
            else
            {
                Console.WriteLine($"Fish {fishCounter}: {match.Groups[0]}");
                Console.WriteLine($"  Tail type: {currentFish.tailType}");
                Console.WriteLine($"  Body type: {currentFish.bodyType } ({ bodyLength} cm)");
                Console.WriteLine($"  Status: {currentFish.status }");
            }
        }

        private static void GetFishDetails(FishDetails currentFish, int tailLength, int bodyLength, string status)
        {
            if (tailLength < 1)
            {
                currentFish.tailType = "None";
            }
            else if (tailLength == 1)
            {
                currentFish.tailType = "Short";
            }
            else if (tailLength > 1 && tailLength < 6)
            {
                currentFish.tailType = "Medium";
            }
            else
            {
                currentFish.tailType = "Long";
            }
            if (bodyLength > 10)
            {
                currentFish.bodyType = "Long";
            }
            else if (bodyLength > 5 && bodyLength < 11)
            {
                currentFish.bodyType = "Medium";
            }
            else
            {
                currentFish.bodyType = "Short";
            }
            switch (status)
            {
                case "'":
                    currentFish.status = "Awake";
                    break;
                case "-":
                    currentFish.status = "Asleep";
                    break;
                case "x":
                    currentFish.status = "Dead";
                    break;
            }
        }
    }
}
