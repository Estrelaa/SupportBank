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
            // init classes if needed
            parseListAll parseListAll = new parseListAll();
             
            //Variables needed        
            string accountNameTofind = "";
            List<string> contentofFileWhenSplit = new List<string>();

            // Read the files and create accounts
            ReadFiles.ReadCSV(out contentofFileWhenSplit, out string[] contentsOfFile);
            parseListAll.parseContentForValues(contentofFileWhenSplit, 1, parseListAll.accountNameAndMoney);

            //Output to the console
            DisplayToConsole.OutputData(parseListAll.accountNameAndMoney, accountNameTofind, contentsOfFile);
        }

    }
}
