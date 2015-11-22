namespace DomainNameGeneratorTool
{
    using System;

    public static class RandomLetterGenerator
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);

        public static char GenerateLetter()
        {
            bool isCapitalLetter = Convert.ToBoolean(random.Next(0, 2));

            if (isCapitalLetter)
            {
                int lowerCaseLetterPosition = random.Next(0, 26);
                char letter = (char)('A' + lowerCaseLetterPosition);

                return letter;
            }
            else
            {
                int lowerCaseLetterPosition = random.Next(0, 26); 
                char letter = (char)('a' + lowerCaseLetterPosition);

                return letter;
            }
        }
    }
}
