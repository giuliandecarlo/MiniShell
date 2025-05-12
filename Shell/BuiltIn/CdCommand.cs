using System;
using System.IO;

namespace Shell.BuiltIn
{
    public class CdCommand: IBuiltInCommand
    {
        public bool CanHandle(string name) => name == "cd";

        public void Execute(string[] args)
        {
            string target;
            if (args.Length == 0)
            {
                target = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }
            else
            {
                target = args[0];
            }
            
            try
            {
                Directory.SetCurrentDirectory(target);
            }
            catch(Exception ex)
            {
                Console.Write($"cd error: {ex.Message}");
            }
        }

    }
}