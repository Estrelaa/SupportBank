using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables needed
            List<string> contentofFileWhenSplit = new List<string>();
            Dictionary<string, float> accountNameAndMoney = new Dictionary<string, float>();
            string accountNameTofind = "";


            //Open the .csv file, save it as a array then join it into 1 long string to get rid of all the \n's
            string[] contentsOfFile = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv");
            string convertContentsToOneString = string.Join(",", contentsOfFile);
            contentsOfFile.ToList();

            //Split the long string so every value in the .csv is its own element
            contentofFileWhenSplit = convertContentsToOneString.Split(",").ToList();

            //Run List All function
            parseContentForValues(contentofFileWhenSplit, 1, accountNameAndMoney);

            //Output to the console
            OutputData(accountNameAndMoney, accountNameTofind, contentsOfFile);
        }

        private static void findTransactonsForOnePerson(string accountNameTofind, string[] contentsOfFile)
        {
            string[] match = { "" };
            float AccountTotal = 0;

            foreach (string element in contentsOfFile)
            {
                if (Regex.IsMatch(element, @"" + accountNameTofind + ""))
                {
                    match = element.Split(",");

                    if (match[1] == accountNameTofind)
                    {
                        Console.WriteLine("{0} owes £{1} to {2} because of {3} on {4} ", match[1], match[4], match[2], match[3], match[0]);
                        AccountTotal = AccountTotal - float.Parse(match[4]);
                    }
                    else
                    {
                        Console.WriteLine("{0} is owed £{1} from {2} because of {3} on {4} ", match[2], match[4], match[1], match[3], match[0]);
                        AccountTotal = AccountTotal + float.Parse(match[4]);
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("{0} has a total balance of: £{1}", accountNameTofind, AccountTotal);
        }

        private static void OutputData(Dictionary<string, float> accountNameAndMoney, string accountNameTofind, string[] contentsOfFile)
        {
            string userInput = "";
            //The loop ensures that if the input is wrong then the user can try again without exiting the program
            while (true)
            {
                Console.WriteLine("Commands are: ");
                Console.WriteLine("List All: output the names of each person, and the total amount they owe, or are owed.");
                Console.WriteLine("Account Transactions: print a list of every transaction, with the date and narrative, for that account.");
                Console.WriteLine("");
                Console.WriteLine("Input command: ");
                try
                {
                    userInput = Console.ReadLine();
                }
                //to make sure numbers and symbols don't crash the program
                catch (IOException)
                {
                    Console.WriteLine("Invaild input, only 'List All' and 'Account Transactions' are vaild!");
                }

                //Run the code that will work out all of the transactions for one person in detail, then print them
                if (userInput == "Account Transactions")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Input the account name you are looking for:");
                    accountNameTofind = Console.ReadLine();
                    findTransactonsForOnePerson(accountNameTofind, contentsOfFile);
                    break;
                }

                // Give a overview of the total balance of everyone
                if (userInput == "List All")
                {
                    Console.WriteLine("");
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
                    break;
                }
                // if the commands are wrong, give an error and stay in the loop
                else
                {
                    Console.WriteLine("Invaild input, only 'List All' and 'Account Transactions' are vaild!");
                }
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
                    //try to get the money of this transaction, convert it to a float and save it.
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
