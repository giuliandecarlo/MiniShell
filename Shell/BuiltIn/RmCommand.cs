using System;
using System.IO;

namespace Shell.BuiltIn
{
    public class RmCommand : IBuiltInCommand
    {
        public bool CanHandle(string name) => name == "rm";

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("rm: missing operand");
                return;
            }

            foreach (var arg in args)
            {
                try
                {
                    string fullPath = Path.Combine(Environment.CurrentDirectory, arg);

                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                    else if (Directory.Exists(fullPath))
                    {
                        Console.WriteLine($"rm: cannot remove '{arg}': Is a directory");
                    }
                    else
                    {
                        Console.WriteLine($"rm: cannot remove '{arg}': No such file");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"rm: error removing '{arg}': {ex.Message}");
                }
            }
        }
    }
}
