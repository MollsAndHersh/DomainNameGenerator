namespace DomainNameGeneratorTests
{
    using System;
    using System.Text.RegularExpressions;
    using DomainNameGeneratorTool;
    using Xunit;

    public class DomainNameGeneratorUnitTests
    {
        Regex regex = new Regex(@"^[a-zA-Z0-9]+(-[a-zA-Z0-9]+)*(\.[a-zA-Z0-9]+(-[a-zA-Z0-9]+)*)+$");

        [Fact]
        public void DomainNameGeneratorTests()
        {
            for (int tries = 0; tries < 1000; ++tries)
            {
                Random random = new Random();
                int labels = random.Next(1, 40);
                string domainName = RandomDomainNameGenerator.GenerateDomainName(labels);

                Assert.True(regex.IsMatch(domainName), string.Format("The domain name '{0}' is not valid", domainName));
            }
        }
    }
}
