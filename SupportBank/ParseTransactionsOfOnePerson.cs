using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SupportBank
{
    class ParseTransactionsOfOnePerson
    {
        public static void FindTransactonsForOnePerson(string accountNameTofind, string[] contentsOfFile)
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
    }
}
