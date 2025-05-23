using System;
using System.IO;

namespace Shell.BuiltIn
{
    public class CatCommand : IBuiltInCommand
    {
        public bool CanHandle(string name) => name == "cat";

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("cat: missing operand");
                return;
            }
            foreach (var filePath in args)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"cat: {filePath}: No such file");
                        continue;
                    }

                    string content = File.ReadAllText(filePath);
                    Console.WriteLine("");
                    Console.WriteLine(content);
                }
                catch (Exception ex)
                {
                    Console.Write($"cat error: {ex.Message}");
                }
            }
        }
    }
}