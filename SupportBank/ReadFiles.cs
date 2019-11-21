using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SupportBank
{
    class ReadFiles
    {
        public static void ReadCSV(out List<string> contentofFileWhenSplit, out string[] contentsOfFile)
        {
            //Open the .csv file, save it as a array then join it into 1 long string to get rid of all the \n's
            contentsOfFile = File.ReadAllLines("C:\\Work\\Training\\SupportBank\\Transactions2014.csv");
            string convertContentsToOneString = string.Join(",", contentsOfFile);
            contentsOfFile.ToList();

            //Split the long string so every value in the .csv is its own element
            contentofFileWhenSplit = convertContentsToOneString.Split(",").ToList();
        }
    }
}
