using System;
using System.IO;

namespace Shell.BuiltIn
{
    public class TouchCommand: IBuiltInCommand
    {
        public bool CanHandle(string name)=> name == "touch";

        public void Execute(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("touch: Missing operand.");
            }
            foreach(var filename in args)
            {
                try
                {
                    string fullPath = Path.Combine(Environment.CurrentDirectory, filename);
                    if(File.Exists(fullPath))
                    {
                        File.SetLastWriteTime(fullPath, DateTime.Now);
                    }
                    else
                    {
                        using (File.Create(fullPath)) { }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine($"touch: Cannot create file '{args[0]}': {ex.Message}");
                }
            } 
        }
    }
}