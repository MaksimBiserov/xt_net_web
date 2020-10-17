using System;
using System.Collections.Generic;
using System.IO;

namespace Task_4_1_1_FILE_MANAGEMENT_SYSTEM
{
    internal class Recovery
    {
        // filling the dictionary with data from the log file

        private static Dictionary<DateTime, string> dictionaryLogData = new Dictionary<DateTime, string>();
        private static DateTime date;
        private static string[] linesFile = File.ReadAllLines(CreatorDefault.PathLog);

        internal static void Recover(DateTime dateValue)
        {
            AddToDictionary();

            // replacing the MainFolder content with the contents of the backup folder

            UpdateDirectory(dateValue);
        }

        private static void AddToDictionary()
        {
            for (int i = 0; i < linesFile.Length; i++)
            {
                if (DateTime.TryParse(linesFile[i], out date) && !dictionaryLogData.ContainsKey(date))
                {
                    dictionaryLogData.Add(date, linesFile[i + 1]);
                }
            }
        }

        private static void UpdateDirectory(DateTime dateValue)
        {
            try
            {
                foreach (var item in dictionaryLogData)
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

            catch (IOException ex) // if an exception occurs, "file is not empty"
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}