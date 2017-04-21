namespace _05ME.Commits
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Commit
    {
        public string Hash { get; set; }

        public string Message { get; set; }

        public int Additions { get; set; }

        public int Deletions { get; set; }

    }

    public class Commits
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var users = new SortedDictionary<string, SortedDictionary<string, List<Commit>>>();

            while (inputLine != "git push")
            {
                var pattern = @"\bhttps:\/\/github.com\/([A-Za-z-\d]+)\/([A-Za-z-_]+)\/commit\/([\da-f]{40}),([^\n]+),(\d+),(\d+)\b";
                var urlsValidation = new Regex(pattern);
                var isMatch = urlsValidation.IsMatch(inputLine);

                if (isMatch)
                {
                    MatchUsersAndRepositories(inputLine, users, urlsValidation);
                }

                inputLine = Console.ReadLine();
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}:");

                foreach (var repo in user.Value)
                {
                    Console.WriteLine($"  {repo.Key}:");
                    var additionsSum = 0;
                    var deletionsSum = 0;

                    foreach (var item in repo.Value)
                    {
                        Console.WriteLine($"    commit {item.Hash}: {item.Message} ({item.Additions} additions, {item.Deletions} deletions)");
                        additionsSum += item.Additions;
                        deletionsSum += item.Deletions;
                    }

                    Console.WriteLine($"    Total: {additionsSum} additions, {deletionsSum} deletions");
                }
            }
        }

        private static void MatchUsersAndRepositories(string inputLine, SortedDictionary<string, SortedDictionary<string, List<Commit>>> users, Regex urlsValidation)
        {
            var match = urlsValidation.Match(inputLine);
            var currentUser = match.Groups[1].ToString();
            var currentRepo = match.Groups[2].ToString();
            var currentHash = match.Groups[3].ToString();
            var currentMessage = match.Groups[4].ToString();
            var currentAddition = int.Parse(match.Groups[5].ToString());
            var currentDeletion = int.Parse(match.Groups[6].ToString());

            var currentCommit = new Commit()
            {
                Hash = currentHash,
                Message = currentMessage,
                Additions = currentAddition,
                Deletions = currentDeletion
            };

            if (!users.ContainsKey(currentUser))
            {
                users.Add(currentUser, new SortedDictionary<string, List<Commit>>());
            }
            if (!users[currentUser].ContainsKey(currentRepo))
            {
                users[currentUser].Add(currentRepo, new List<Commit>());
            }

            users[currentUser][currentRepo].Add(currentCommit);
        }
    }
}
