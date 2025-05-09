using System;

namespace Shell
{
    public class MiniShell
    {
        private readonly CommandExecutor executor = new CommandExecutor();
        public void Run()
        {
            while(true)
            {
                Console.Write(">");
                string input = Console.ReadLine()?.Trim();
                if( string.IsNullOrEmpty(input)) continue;
                if(input == "exit") break;

                var command = CommandParser.Parse(input);
                executor.Execute(command);
            }
        }
    }
}