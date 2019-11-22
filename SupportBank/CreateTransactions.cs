using System;
using System.Text.RegularExpressions;

namespace SupportBank
{
    class CreateTransactions
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
                    //TODO: Add try/catch to deal with "One Cheeseburger" in the amount colum becausing of ******* Ben
                    if (match[1] == accountNameTofind)
                    {
                        try
                        {
                            Console.WriteLine("{0} need to pay £{1} to {2} because of {3} on {4} ", match[1], Math.Round(float.Parse(match[4]), 2), match[2], match[3], match[0]);
                            AccountTotal = AccountTotal - float.Parse(match[4]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("A Value in this transaction is in a invaild format, skipping...");
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("{0} Should be paid £{1} from {2} because of {3} on {4} ", match[2], Math.Round(float.Parse(match[4]), 2), match[1], match[3], match[0]);
                            AccountTotal = AccountTotal + float.Parse(match[4]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("A Value in this transaction is in a invaild format, skipping...");
                        }
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("{0} has a total balance of: £{1}", accountNameTofind, Math.Round(AccountTotal, 2) * -1);
        }
    }
}
