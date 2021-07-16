using System;
using System.Linq;

namespace CricketKit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter purchase details");
            string input = Console.ReadLine();

            InputParserResult result = new InputParser().TryParse(input);
            if (result.Errors.Count > 0)
            {
                Console.WriteLine(string.Join(";", result.Errors));
            }
            else
            {
                new Printer().Print(result.PurchaseDetail);
            }
            Console.ReadLine();
        }
    }
}
