using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SupportBank
{
    class ReadFiles
    {
        public static void ReadCSV(out List<string> contentofFileWhenSplit, out string[] contentsOfFile)
        {
            //Open the .csv files, save it as a list to add both files in, then join it into 1 long string to get rid of all the \n's
            List<string> contentsOfFiletemp = new List<string>();

            contentsOfFiletemp = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv").ToList();
            contentsOfFiletemp.AddRange(File.ReadAllLines("C:\\Work\\Training\\SupportBank\\DodgyTransactions2015.csv").ToList());
            contentsOfFile = contentsOfFiletemp.ToArray();

            string convertContentsToOneString = string.Join(",", contentsOfFile);

            //Split the long string so every value in the .csv is its own element, needed for the CreateAccounts method in parseAccounts.cs
            contentofFileWhenSplit = convertContentsToOneString.Split(",").ToList();
        }
    }
}
