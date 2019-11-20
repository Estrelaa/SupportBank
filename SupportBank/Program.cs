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

            /*Theses list and the element number match the same transaction,
             * for example element [2] on all the lists make one transaction
             */
            List<string> dateOfTransaction = new List<string>();
            List<string> peopleThatOwnMoney = new List<string>();
            List<string> PeopleThatAreOwnedMoney = new List<string>();
            List<string> howMuchTheyAreOwned = new List<string>();

            //Open the .csv file, save it as a array then join it into 1 long string to get rid of all the \n's
            string[] contentsOfFile = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv");
            string convertContentsToOneString = string.Join(",", contentsOfFile);

            //Split the long string so every value in the .csv is its own element
            contentofFileSplit = convertContentsToOneString.Split(",").ToList();


            //Run parser for every needed colum
            parseContentForValues(contentofFileSplit, 1, dateOfTransaction);
            parseContentForValues(contentofFileSplit, 2, peopleThatOwnMoney);
            parseContentForValues(contentofFileSplit, 3, PeopleThatAreOwnedMoney);
            parseContentForValues(contentofFileSplit, 4, howMuchTheyAreOwned);


            //Stops the console from closing
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
