using System;
using System.IO;
using System.Collections.Generic;

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
                var files = new List <string>();
                foreach(var entry in entries)
                {
                    files.Add(Path.GetFileName(entry));
                }
                Console.WriteLine(string.Join(" ",files));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ls error: {ex.Message}");
            }
        }
    }
}