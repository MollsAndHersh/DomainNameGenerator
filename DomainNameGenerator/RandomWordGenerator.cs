﻿namespace DomainNameGeneratorTool
{
    using System;
    using System.Text;

    public static class RandomWordGenerator
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);

        public static string GenerateWord(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < length; ++i)
            {
                stringBuilder.Append(RandomLetterGenerator.GenerateLetter());
            }

            return stringBuilder.ToString();
        }
    }
}
