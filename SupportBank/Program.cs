using System.Collections.Generic;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables needed that are not part of a class and init classes if needed  
            string accountNameTofind = "";
            List<string> contentofFileWhenSplit = new List<string>();
            ParseAccounts parseListAll = new ParseAccounts();

            ReadFiles.ReadCSV(out contentofFileWhenSplit, out string[] contentsOfFile);
            ParseAccounts.CreateAccounts(contentofFileWhenSplit, 1, parseListAll.accountNameAndMoney);

            DisplayToConsole.OutputData(parseListAll.accountNameAndMoney, accountNameTofind, contentsOfFile);
        }
    }
}
