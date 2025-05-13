using System;
using System.IO;

namespace Shell.BuiltIn
{
    public class PwdCommand: IBuiltInCommand
    {
        public bool CanHandle(string name) => name == "pwd";

        public void Execute(string[] args)
        {
            string currentDir = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDir);
        }
    }
}