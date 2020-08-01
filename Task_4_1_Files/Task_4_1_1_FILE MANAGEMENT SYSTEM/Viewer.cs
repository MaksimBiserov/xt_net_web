using System.IO;

namespace Task_4_1_1_FILE_MANAGEMENT_SYSTEM
{

    // change monitoring class

    internal class Viewer
    {
        internal static void View()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = CreatorDefault.PathMain;
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess
                                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Filter = "*.*";
            watcher.Created += new FileSystemEventHandler(WriterContent.OnCreated);
            watcher.Renamed += new RenamedEventHandler(WriterContent.OnRenamed);
            watcher.Changed += new FileSystemEventHandler(WriterContent.OnChanged);
            watcher.Deleted += new FileSystemEventHandler(WriterContent.OnDeleted);
            watcher.EnableRaisingEvents = true;
        }
    }
}