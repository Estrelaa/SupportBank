using System;
using System.Collections.Generic;
using System.IO;

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
                Console.Clear();
                Console.WriteLine("Commands are: ");
                Console.WriteLine("List All: output the names of each person, and the total amount they owe, or are owed.");
                Console.WriteLine("Account Transactions: print a list of every transaction, with the date and narrative, for that account.");
                Console.WriteLine("");
                Console.WriteLine("Input command: ");
                try
                {
                    userInput = Console.ReadLine();
                }
                //to make sure numbers and symbols don't crash the program as userInput is a string
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
                    ParseTransactions.FindAccountTransactions(accountNameTofind, contentsOfFile);

                    //Stops the console from closing
                    Console.ReadLine();
                }

                // Give a overview of the total balance of everyone
                if (userInput == "List All")
                {
                    Console.WriteLine("");
                    //For each account, saythe status of their account. We round up the values to 2 D.P. here to make it look nicer
                    foreach (KeyValuePair<string, float> key in accountNameAndMoney)
                    {
                        if (key.Value > 0)
                        {
                            Console.WriteLine("{0} should be paid £{1}", key.Key,Math.Round(key.Value, 2));
                        }
                        else
                        {                         
                            Console.WriteLine("{0} is £{1} in debt ", key.Key, Math.Round(key.Value, 2) * -1); //Makes the number posative
                        }
                    }
                    //Stops the console from closing
                    Console.ReadLine();
                }
                // if the commands are wrong, give an error and stay in the loop
                else
                {
                    Console.WriteLine("Invaild input, only 'List All' and 'Account Transactions' are vaild!");
                }
            }
        }
    }
}
