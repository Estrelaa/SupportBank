using System.Collections.Generic;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // init classes if needed
            parseAccounts parseListAll = new parseAccounts();
             
            //Variables needed that are not part of a class     
            string accountNameTofind = "";
            List<string> contentofFileWhenSplit = new List<string>();

            // Read the files and create accounts
            ReadFiles.ReadCSV(out contentofFileWhenSplit, out string[] contentsOfFile);
            parseAccounts.CreateAccounts(contentofFileWhenSplit, 1, parseListAll.accountNameAndMoney);

            //Output to the console
            DisplayToConsole.OutputData(parseListAll.accountNameAndMoney, accountNameTofind, contentsOfFile);
        }
    }
}
