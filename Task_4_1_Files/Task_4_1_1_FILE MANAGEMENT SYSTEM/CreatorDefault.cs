using System.IO;

namespace Task_4_1_1_FILE_MANAGEMENT_SYSTEM
{

    // this class creates a folder and file structure
    // to work with when the program is first started,
    // as well as when it is deleted

    internal class CreatorDefault
    {
        internal static string PathMain => @"C:\FileManagementSystem\MainFolder";
        internal static string PathRecovery => @"C:\FileManagementSystem\RecoveryFolder";
        internal static string PathLog => @"C:\FileManagementSystem\log.txt";

        internal static void CreateSourceFilesAndFolders()
        {
            DirectoryInfo directoryMain = new DirectoryInfo(PathMain);

            if (!directoryMain.Exists)
            {
                directoryMain.Create();
            }

            DirectoryInfo directoryRecovery = new DirectoryInfo(PathRecovery);

            if (!directoryRecovery.Exists)
            {
                directoryRecovery.Create();
            }

            FileInfo fileLog = new FileInfo(PathLog);

            if (!fileLog.Exists)
            {
                fileLog.Create().Close();
            }
        }
    }
}