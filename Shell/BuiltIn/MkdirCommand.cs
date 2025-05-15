using System;
using System.IO;

namespace Shell.BuiltIn
{
    public class MkdirCommand: IBuiltInCommand
    {
        public bool CanHandle(string name) => name == "mkdir";

        public void Execute(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("mkdir: Missing operand.");
                return;
            }

            foreach(var dir in args)
            {
                try
                {
                    string fullPath = Path.Combine(Environment.CurrentDirectory, dir);
                    Directory.CreateDirectory(fullPath);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"mkdir: Cannot create directory '{dir}': {ex.Message}");
                }
            }
        }
    }
}