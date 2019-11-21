using System.Collections.Generic;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggingInit();
            //Variables needed that are not part of a class and init classes if needed  
            string accountNameTofind = "";
            List<string> contentofFileWhenSplit = new List<string>();
            ParseAccounts parseListAll = new ParseAccounts();

            ReadFiles.ReadCSV(out contentofFileWhenSplit, out string[] contentsOfFile);
            ParseAccounts.CreateAccounts(contentofFileWhenSplit, 1, parseListAll.accountNameAndMoney);

            DisplayToConsole.OutputData(parseListAll.accountNameAndMoney, accountNameTofind, contentsOfFile);
        }

        private static void LoggingInit()
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
        }
    }
}
