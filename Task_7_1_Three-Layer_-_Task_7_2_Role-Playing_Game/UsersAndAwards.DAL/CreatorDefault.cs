using System.IO;

namespace UsersAndAwards.DAL
{
    internal class CreatorDefault
    {
        internal static string PathFolder => @"../../UsersAndAwards.JSON";
        internal static string PathUser => @"../../UsersAndAwards.JSON/UserData.json";
        internal static string PathAward => @"../../UsersAndAwards.JSON/AwardData.json";
        internal static string PathBindingUserAward => @"../../UsersAndAwards.JSON/BindingUserAwardData.json";
        internal static string PathRegistrator => @"../../UsersAndAwards.JSON/Registrator.json";

        internal static void CreateSourceFilesAndFolders()
        {
            DirectoryInfo directoryMain = new DirectoryInfo(PathFolder);

            if (!directoryMain.Exists)
            {
                directoryMain.Create();
            }

            FileInfo fileUser = new FileInfo(PathUser);

            if (!fileUser.Exists)
            {
                fileUser.Create().Close();
            }

            FileInfo fileAward = new FileInfo(PathAward);

            if (!fileAward.Exists)
            {
                fileAward.Create().Close();
            }

            FileInfo fileBinding = new FileInfo(PathBindingUserAward);

            if (!fileBinding.Exists)
            {
                fileBinding.Create().Close();
            }

            FileInfo fileRegistrator = new FileInfo(PathRegistrator);

            if (!fileRegistrator.Exists)
            {
                fileRegistrator.Create().Close();
            }
        }
    }
}