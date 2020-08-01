using System;
using System.Collections.Generic;
using System.IO;

namespace Task_4_1_1_FILE_MANAGEMENT_SYSTEM
{
    internal class Recovery
    {
        internal static void Recover(DateTime dateValue)
        {
            // filling the dictionary with data from the log file

            Dictionary<DateTime, string> dictionary = new Dictionary<DateTime, string>();
            DateTime date;
            string[] linesFile = File.ReadAllLines(CreatorDefault.PathLog);

            for (int i = 0; i < linesFile.Length; i++)
            {
                if (DateTime.TryParse(linesFile[i], out date) && !dictionary.ContainsKey(date))
                {
                    dictionary.Add(date, linesFile[i + 1]);
                }
            }

            // replacing the MainFolder content with the contents of the backup folder

            try
            {
                foreach (var item in dictionary)
                {
                    if (item.Key >= dateValue)
                    {
                        Directory.Delete(CreatorDefault.PathMain, true);
                        Directory.CreateDirectory(CreatorDefault.PathMain);
                        WriterContent.CopyFiles(item.Value, CreatorDefault.PathMain);
                        break;
                    }
                }
            }

            catch(IOException ex) // if an exception occurs, "file is not empty"
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}