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
            string userInput = "";

            //Open the .csv file, save it as a array then join it into 1 long string to get rid of all the \n's
            string[] contentsOfFile = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv");
            string convertContentsToOneString = string.Join(",", contentsOfFile);

            //Split the long string so every value in the .csv is its own element
            contentofFileSplit = convertContentsToOneString.Split(",").ToList();

            //Run parser
            parseContentForValues(contentofFileSplit, 1, accountNameAndMoney);

            userInput = OutputData(accountNameAndMoney);

        }

        private static string OutputData(Dictionary<string, float> accountNameAndMoney)
        {
            string userInput;
            while (true)
            {
                Console.WriteLine("Commands are: ");
                Console.WriteLine("List All: output the names of each person, and the total amount they owe, or are owed.");
                Console.WriteLine("List [Name Of Person]: print a list of every transaction, with the date and narrative, for that account with that name.");
                Console.WriteLine("");
                Console.WriteLine("Input command: ");
                try
                {
                    userInput = Console.ReadLine().ToLower();
                    break;
                }
                catch (IOException)
                {
                    Console.WriteLine("Invaild input, only 'List All' and 'List[Name of person you are looking for] are vaild!");
                }
            }

            Console.WriteLine("");

            if (userInput == "list all")
            {
                foreach (KeyValuePair<string, float> key in accountNameAndMoney)
                {
                    if (key.Value > -0)
                    {
                        Console.WriteLine("{0} are owned £{1}", key.Key, key.Value);
                    }
                    else
                    {
                        Console.WriteLine("{0} owe £{1}", key.Key, key.Value);
                    }
                }

            }
            //Stops the console from closing
            Console.ReadLine();
            return userInput;
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
