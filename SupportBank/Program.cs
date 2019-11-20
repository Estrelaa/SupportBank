using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables needed
            string[] contentsOfFile = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv");
            string Record = string.Join(",", contentsOfFile);
            List<string> contentofFileSplit = new List<string>();


            //parse data into account names
            contentofFileSplit = Record.Split(",").ToList();

            for (int i = 1; i < contentofFileSplit.Count; i++)
            {
                if (i % 5 == 1)
                {
                    Console.WriteLine(contentofFileSplit[i]);
                }

            }

            //accountName.ForEach(Console.WriteLine);
            Console.ReadLine();

        }
    }
}
