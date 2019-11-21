using System.Collections.Generic;
using NLog;

namespace SupportBank
{
    class ParseAccounts
    {
        //Enable Logging on this class 
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        // Variables For the method to run        
        public Dictionary<string, float> accountNameAndMoney = new Dictionary<string, float>();

        public static Dictionary<string, float> CreateAccounts(List<string> contentofFileSplit, int FromColumNumber,
            Dictionary<string, float> accountNameAndMoney)
        {
            for (int i = 3; i < contentofFileSplit.Count; i++)
            {
                float moneyInTransaction = 0;
                if (i % 5 == FromColumNumber)
                {
                    try
                    {
                        moneyInTransaction = float.Parse(contentofFileSplit[i + 3]);
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
                    accountNameAndMoney[contentofFileSplit[i]] = accountNameAndMoney[contentofFileSplit[i]] + moneyInTransaction;
                    accountNameAndMoney[contentofFileSplit[i + 1]] = accountNameAndMoney[contentofFileSplit[i + 1]] - moneyInTransaction;
                }
            }
            return accountNameAndMoney;
        }
    }
}
