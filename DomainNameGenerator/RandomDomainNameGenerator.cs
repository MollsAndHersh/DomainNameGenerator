namespace DomainNameGeneratorTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RandomDomainNameGenerator
    {
        public const int MaxDomainNameLength = 300;

        private static readonly Random random = new Random((int)DateTime.Now.Ticks);

        public static string GenerateDomainName(int numberOfLabels)
        {
            if (numberOfLabels < 1)
            {
                throw new ArgumentException();
            }

            var minLength = numberOfLabels * 3;
            var wordLength = random.Next(minLength, RandomDomainNameGenerator.MaxDomainNameLength + 1);

            string randomWord = RandomWordGenerator.GenerateWord(wordLength);

            IList<int> dotPositions = RandomDomainNameGenerator.GenerateDotPositions(wordLength, numberOfLabels);

            return RandomDomainNameGenerator.ReplaceStringPositionsByDots(randomWord, dotPositions);
        }

        private static IList<int> GenerateDotPositions(int wordLength, int numberOfLabels)
        {
            IList<int> dotPositions = new List<int>();

            while (dotPositions.Count < numberOfLabels)
            {
                int candidateDotPosition = random.Next(1, wordLength - 1);

                if (!dotPositions.Contains(candidateDotPosition)
                    && !dotPositions.Any(position => position == (candidateDotPosition - 1) || position == (candidateDotPosition + 1)))
                {
                    dotPositions.Add(candidateDotPosition);
                }
            }

            return dotPositions;
        }

        private static string ReplaceStringPositionsByDots(string source, IList<int> dotPositions)
        {
            StringBuilder result = new StringBuilder(source);

            foreach (var candidateDotPosition in dotPositions)
            {
                result[candidateDotPosition] = '.';
            }

            return result.ToString();
        }
    }
}
