using System;

namespace Shell.BuiltIn
{
    public class EchoCommand: IBuiltInCommand
    {
        public bool CanHandle(string name) => name == "echo";

        public void Execute(string[] args)
        {
            if (args.Length == 0)
                return;
            Console.WriteLine(string.Join(" ", args));
        }
    }
}