using LD39.Entity;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class CommandManager
    {
        private Action<List<string>> commandAction;
        private Dictionary<string, Command> commands = new Dictionary<string, Command>();

        private City city = new City(new Vector2(0, 0), null);

        public CommandManager(Action<List<string>> commandCallback)
        {
            commandAction = commandCallback;
        }

        public void Init(LD39.Entity.Console console)
        {
            Command com = new HelpCommand(commandAction);
            commands.Add(com.Name.ToLowerInvariant(), com);

            com = new CommandsCommand(commandAction, commands);
            commands.Add(com.Name.ToLowerInvariant(), com);

            com = new ScreenCommand(commandAction, console);
            commands.Add(com.Name.ToLowerInvariant(), com);

            DdosCommand ddosCom = new DdosCommand(commandAction);
            ddosCom.city = city;
            commands.Add(com.Name.ToLowerInvariant(), ddosCom);

        }

        public void ParseCommand(string command, Dictionary<string, string> arguments)
        {

            if (commands.ContainsKey(command.ToLowerInvariant()))
            {
                commands[command.ToLowerInvariant()].PerformCommand(arguments);
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
