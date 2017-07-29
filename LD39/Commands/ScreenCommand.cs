using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class ScreenCommand : Command
    {
        private LD39.Entity.Console console;

        public ScreenCommand(Action<List<string>> commandCallback, LD39.Entity.Console consoleScreen) : base(commandCallback)
        {
            Name = "screen";
            console = consoleScreen;
        }

        public override void DisplayHelp()
        {
            feedback.Add("TODO: Insert help here");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Screen command can be used with: -r <reset> or -c <clear>");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            return true;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-c") || arguments.ContainsKey("-clear"))
            {
                console.Clear();
                return;
            }

            if (arguments.ContainsKey("-r") || arguments.ContainsKey("-reset"))
            {
                console.Reset();
                return;
            }

            if (arguments.ContainsKey("-tc") || arguments.ContainsKey("-textcolor"))
            {
                string color = arguments["-tc"];

                if (color == "red") console.ConsoleTextColor = Color.Red;
                if (color == "blue") console.ConsoleTextColor = Color.Blue;
                if (color == "yellow") console.ConsoleTextColor = Color.Yellow;
                if (color == "green") console.ConsoleTextColor = Color.Green;
                if (color == "orange") console.ConsoleTextColor = Color.Orange;
                if (color == "purple") console.ConsoleTextColor = Color.Purple;
                if (color == "black") console.ConsoleTextColor = Color.Black;
                if (color == "white") console.ConsoleTextColor = Color.White;
            }

            if (arguments.ContainsKey("-sc") || arguments.ContainsKey("-screencolor"))
            {
                string color = arguments["-sc"];

                if (color == "red") console.ConsoleColor = Color.Red;
                if (color == "blue") console.ConsoleColor = Color.Blue;
                if (color == "yellow") console.ConsoleColor = Color.Yellow;
                if (color == "green") console.ConsoleColor = Color.Green;
                if (color == "orange") console.ConsoleColor = Color.Orange;
                if (color == "purple") console.ConsoleColor = Color.Purple;
                if (color == "black") console.ConsoleColor = Color.Black;
                if (color == "white") console.ConsoleColor = Color.White;
            }

            commandAction(null);
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }
    }
}
