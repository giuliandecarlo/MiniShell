using System;
using System.Collections.Generic;
using Shell.BuiltIn;

namespace Shell
{
    public class CommandExecutor
    {
        private readonly List<IBuiltInCommand> builtIns = new List<IBuiltInCommand>
        {
            new EchoCommand(),
            new LsCommand(),
            new CdCommand(),
            new PwdCommand(),
            new MkdirCommand(),
            new ClearCommand(),
            new TouchCommand()
        };

        public void Execute(Command command)
        {
            foreach (var handler in builtIns)
            {
                if (handler.CanHandle(command.Name))
                {
                    handler.Execute(command.Args);
                    return;
                }
            }
            RunExternal(command);
        }

        private void RunExternal(Command cmd)
        {
            try
            {
                var process = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = cmd.Name,
                        Arguments = string.Join(' ',cmd.Args),
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false
                    }
                };

                process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.Error.WriteLine(process.StandardError.ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
