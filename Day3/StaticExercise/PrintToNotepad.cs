public static class PrintToNotepad {
    public static void ExportingToNotepad(string path, Dictionary<int, string> necklaceRecord) {
        //
        FileInfo f1 = new FileInfo(@path);
        FileStream fsToWrite = f1.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        StreamWriter sw = new StreamWriter(fsToWrite);
        foreach(KeyValuePair<int,string> kvp in necklaceRecord) {
            sw.WriteLine("The necklace id {0} stands for {1}", kvp.Key, kvp.Value);
        }
        sw.Close();
        fsToWrite.Close();
        Console.WriteLine("Done Writing the File..");
    }
}