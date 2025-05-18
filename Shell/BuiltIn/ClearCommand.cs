using System;

namespace Shell.BuiltIn
{
    public class ClearCommand: IBuiltInCommand
    {
        public bool CanHandle(string name)=> name == "clear";
        
        public void Execute(string[] args)
        {
            Console.Clear();
        }
    }
}