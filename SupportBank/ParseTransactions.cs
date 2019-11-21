using System;
using System.Text.RegularExpressions;

namespace SupportBank
{
    class ParseTransactions
    {
        public static void FindAccountTransactions(string accountNameTofind, string[] contentsOfFile)
        {
            string[] match = { "" };
            float AccountTotal = 0;

            foreach (string Line in contentsOfFile)
            {
                if (Regex.IsMatch(Line, @"" + accountNameTofind + ""))
                {
                    match = Line.Split(",");

                    if (match[1] == accountNameTofind)
                    {
                        Console.WriteLine("{0} need to pay £{1} to {2} because of {3} on {4} ", match[1], Math.Round(float.Parse(match[4]), 2), match[2], match[3], match[0]);
                        AccountTotal = AccountTotal - float.Parse(match[4]);
                    }
                    else
                    {
                        Console.WriteLine("{0} Should be paid £{1} from {2} because of {3} on {4} ", match[2], Math.Round(float.Parse(match[4]), 2), match[1], match[3], match[0]);
                        AccountTotal = AccountTotal + float.Parse(match[4]);
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("{0} has a total balance of: £{1}", accountNameTofind, Math.Round(AccountTotal, 2));
        }
    }
}
