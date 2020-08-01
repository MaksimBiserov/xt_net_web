using System;
using System.IO;
using System.Text;
using static Task_4_1_1_FILE_MANAGEMENT_SYSTEM.CreatorDefault;

namespace Task_4_1_1_FILE_MANAGEMENT_SYSTEM
{
    internal class WriterContent
    {
        internal static string subDirectory;

        // when the create, rename, change, and delete event occurs,
        // a backup folder with a unique name is created in RecoveryFolder,
        // and the changes are written to a file Log.txt

        internal static void OnCreated(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(PathLog, true, Encoding.Default))
            {
                subDirectory = $"{PathRecovery}\\{Guid.NewGuid()}";
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(subDirectory);
                sw.Write($"File {e.Name} was created. ");
                sw.Write($"The action performed with it: { e.ChangeType}. ");
                sw.Write($"Path to the file: {e.FullPath}." + Environment.NewLine);
                sw.WriteLine("---");
            }

            Directory.CreateDirectory(subDirectory);
            CopyFiles(PathMain, subDirectory);
        }

        internal static void OnRenamed(object sender, RenamedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(PathLog, true, Encoding.Default))
            {
                subDirectory = $"{PathRecovery}\\{Guid.NewGuid()}";
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(subDirectory);
                sw.Write($"File {e.OldFullPath} was renamed to {e.FullPath}. ");
                sw.Write($"The action performed with it: { e.ChangeType}. ");
                sw.Write($"Path to the file: {e.FullPath}." + Environment.NewLine);
                sw.WriteLine("---");
            }

            Directory.CreateDirectory(subDirectory);
            CopyFiles(PathMain, subDirectory);
        }

        internal static void OnChanged(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(PathLog, true, Encoding.Default))
            {
                subDirectory = $"{PathRecovery}\\{Guid.NewGuid()}";
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(subDirectory);
                sw.Write($"File {e.Name} was changed. ");
                sw.Write($"The action performed with it: { e.ChangeType}. ");
                sw.Write($"Path to the file: {e.FullPath}." + Environment.NewLine);
                sw.WriteLine("---");
            }

            Directory.CreateDirectory(subDirectory);
            CopyFiles(PathMain, subDirectory);
        }

        internal static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(PathLog, true, Encoding.Default))
            {
                subDirectory = $"{PathRecovery}\\{Guid.NewGuid()}";
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(subDirectory);
                sw.Write($"File {e.Name} was deleled. ");
                sw.Write($"The action performed with it: { e.ChangeType}. ");
                sw.Write($"Path to the file: {e.FullPath}." + Environment.NewLine);
                sw.WriteLine("---");
            }

            Directory.CreateDirectory(subDirectory);
            CopyFiles(PathMain, subDirectory);
        }

        internal static void CopyFiles(string dirMain, string dirRecovery)
        {
            Directory.CreateDirectory(dirRecovery);

            try
            {
                foreach (string file1 in Directory.GetFiles(dirMain))
                {
                    string file2 = dirRecovery + "\\" + Path.GetFileName(file1);
                    File.Copy(file1, file2, true);
                }
                foreach (string file in Directory.GetDirectories(dirMain))
                {
                    CopyFiles(file, dirRecovery + "\\" + Path.GetFileName(file));
                }
            }
            
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}