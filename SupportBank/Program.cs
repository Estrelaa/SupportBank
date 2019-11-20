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
            Dictionary<string, float> accountNameAndMoney = new Dictionary<string, float>();

            /*Theses list and the element number match the same transaction,
             * for example element [2] on all the lists make one transaction
             */
            List<string> peopleThatOwnMoney = new List<string>();
            List<string> PeopleThatAreOwnedMoney = new List<string>();
            List<string> howMuchTheyAreOwned = new List<string>();

            //Open the .csv file, save it as a array then join it into 1 long string to get rid of all the \n's
            string[] contentsOfFile = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv");
            string convertContentsToOneString = string.Join(",", contentsOfFile);

            //Split the long string so every value in the .csv is its own element
            contentofFileSplit = convertContentsToOneString.Split(",").ToList();


            //Run parser for every needed colum
            parseContentForValues(contentofFileSplit, 1, accountNameAndMoney);


            //Create accounts for each user and how much they own using a dictionary


            foreach (KeyValuePair<string, float> key in accountNameAndMoney)
            {
                Console.WriteLine("{0} ", key);
            }
            //Stops the console from closing
            Console.ReadLine();

        }

        private static void parseContentForValues(List<string> contentofFileSplit, int FromColumNumber,
            Dictionary<string, float> accountNameAndMoney)
        {
            for (int i = 0; i < contentofFileSplit.Count; i++)
            {
                float temp = 0;
                if (i % 5 == FromColumNumber)
                {
                    try
                    {
                        temp = float.Parse(contentofFileSplit[i + 3]);
                    }
                    catch
                    {

                    }
                    // if they are not in the dictionary, add them
                    if (accountNameAndMoney.ContainsKey(contentofFileSplit[i]) == false)
                    {
                        accountNameAndMoney.Add(contentofFileSplit[i], 0);
                    }
                    if (accountNameAndMoney.ContainsKey(contentofFileSplit[i + 1]) == false)
                    {
                        accountNameAndMoney.Add(contentofFileSplit[i + 1], 0);
                    }

                    // update their accounts
                    accountNameAndMoney[contentofFileSplit[i]] = accountNameAndMoney[contentofFileSplit[i]] + temp;
                    accountNameAndMoney[contentofFileSplit[i + 1]] = accountNameAndMoney[contentofFileSplit[i + 1]] - temp;
                }

            }
        }
    }
}
