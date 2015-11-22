using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomainNameGeneratorTool
{
    class Program
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);

        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9]+(-[a-zA-Z0-9]+)*(\.[a-zA-Z0-9]+(-[a-zA-Z0-9]+)*)+$");

            for (int tries = 0; tries < 100; ++tries)
            {
                int labels = random.Next(1, 40);
                Console.WriteLine("Labels: {0}", labels);

                string domainName = RandomDomainNameGenerator.GenerateDomainName(labels);
                Console.WriteLine("Domain: {0}", domainName);

                Debug.Assert(regex.IsMatch(domainName), string.Format("The domain name '{0}' is not valid", domainName));
            }

            Console.ReadLine();
        }
    }
}
