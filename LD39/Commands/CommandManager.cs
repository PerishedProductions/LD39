using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class CommandManager
    {
        private Action<List<string>> commandAction;
        private Dictionary<string, Command> commands = new Dictionary<string, Command>();

        public CommandManager(Action<List<string>> commandCallback)
        {
            commandAction = commandCallback;
        }

        public void Init()
        {
            Command com = new HelpCommand(commandAction);
            commands.Add(com.Name.ToLowerInvariant(), com);
        }

        public void ParseCommand(string command)
        {

            if (commands.ContainsKey(command.ToLowerInvariant()))
            {
                commands[command.ToLowerInvariant()].PerformCommand();
            }
            else
            {
                List<string> feedback = new List<string>();
                feedback.Add($"'{command}' is not recognized as a command. Try 'help' in case you get stuck.");
                commandAction(feedback);
            }

        }
    }
}
