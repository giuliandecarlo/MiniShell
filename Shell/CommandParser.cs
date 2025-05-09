using System;

namespace Shell
{
        public class Command
        {
            public string Name;
            public string[] Args;
        }

    public static class CommandParser
    {
        public static Command Parse(string input)
        {
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                return new Command { Name = "", Args = new string[0] };
            }

            string name = parts[0];
            string[] args;

            if (parts.Length > 1)
            {
                args = new string[parts.Length - 1];
                Array.Copy(parts, 1, args, 0, args.Length);
            }
            else
            {
                args = new string[0];
            }

            return new Command
            {
                Name = name,
                Args = args
            };
        }
    }
}