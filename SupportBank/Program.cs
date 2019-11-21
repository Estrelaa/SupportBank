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

            // init classes
            parseListAll parseListAll = new parseListAll();
            

            //Variables needed           
            string accountNameTofind = "";
            List<string> contentofFileWhenSplit = new List<string>();

            //Open the .csv file, save it as a array then join it into 1 long string to get rid of all the \n's
            string[] contentsOfFile = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv");
            string convertContentsToOneString = string.Join(",", contentsOfFile);
            contentsOfFile.ToList();

            //Split the long string so every value in the .csv is its own element
            contentofFileWhenSplit = convertContentsToOneString.Split(",").ToList();

            //Run List All function
            parseListAll.parseContentForValues(contentofFileWhenSplit, 1, parseListAll.accountNameAndMoney);

            //Output to the console
            OutputData(parseListAll.accountNameAndMoney, accountNameTofind, contentsOfFile);
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
                    ParseTransactionsOfOnePerson.FindTransactonsForOnePerson(accountNameTofind, contentsOfFile);
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
    }
}
