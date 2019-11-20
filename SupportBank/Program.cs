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
            List<string> contentofFileSplit = new List<string>();
            List<string> Record = new List<string>();

            //Open the .csv file, save it as a array then join it into 1 long string to get rid of all the \n's
            string[] contentsOfFile = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv");
            string convertContentsToOneString = string.Join(",", contentsOfFile);

            //Split the long string so every value in the .csv is its own element
            contentofFileSplit = convertContentsToOneString.Split(",").ToList();


            parseContentForValues(contentofFileSplit, 1, Record);

            //accountName.ForEach(Console.WriteLine);

            Console.ReadLine();

        }

        private static void parseContentForValues(List<string> contentofFileSplit, int ColumNumber,
            List<string> variableToHoldRecords)
        {
            for (int i = 1; i < contentofFileSplit.Count; i++)
            {
                if (i % 5 == ColumNumber)
                {
                    variableToHoldRecords.Add(contentofFileSplit[i]);
                }

            }
        }
    }
}
