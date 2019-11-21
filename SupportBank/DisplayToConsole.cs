using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SupportBank
{
    class DisplayToConsole
    {
        public static void OutputData(Dictionary<string, float> accountNameAndMoney, string accountNameTofind, string[] contentsOfFile)
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
