using System;
using System.IO;

namespace Shell.BuiltIn
{
    public class LsCommand: IBuiltInCommand
    {
        public bool CanHandle(string name) => name == "ls";

        public void Execute(string[] args)
        {
            var path = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
            try
            {
                var entries = Directory.GetFileSystemEntries(path);
                foreach(var entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ls error: {ex.Message}");
            }
        }
    }
}