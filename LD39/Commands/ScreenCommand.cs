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
            feedback.Add("The screen command is used to configure the console.");
            feedback.Add("The screen command can also be used to clear or reset the console.");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: screen [-c] [-r] [-tc] [-sc]");
            feedback.Add("Optional argument: -c or -clear");
            feedback.Add("Clears the console screen of any log");
            feedback.Add("Optional argument: -r or -reset");
            feedback.Add("Resets the console screen to defaults");
            feedback.Add("Optional argument: -tc or -textcolor");
            feedback.Add("Change the console text color, accepted values: red, blue, yellow, green, purple, orange");
            feedback.Add("Optional argument: -sc or -screencolor");
            feedback.Add("Change the console color, accepted values: red, blue, yellow, green, purple, orange");
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

            string color = "white";

            if (arguments.TryGetValue("-tc", out color) || arguments.TryGetValue("-textcolor", out color))
            {
                if (color == "red") console.ConsoleTextColor = Color.Red;
                if (color == "blue") console.ConsoleTextColor = Color.Blue;
                if (color == "yellow") console.ConsoleTextColor = Color.Yellow;
                if (color == "green") console.ConsoleTextColor = Color.Green;
                if (color == "orange") console.ConsoleTextColor = Color.Orange;
                if (color == "purple") console.ConsoleTextColor = Color.Purple;
                if (color == "black") console.ConsoleTextColor = Color.Black;
                if (color == "white") console.ConsoleTextColor = Color.White;
                if (string.IsNullOrEmpty(color)) console.ConsoleTextColor = Color.White;
            }

            color = "black";

            if (arguments.TryGetValue("-sc", out color) || arguments.TryGetValue("-screencolor", out color))
            {
                if (color == "red") console.ConsoleColor = Color.Red;
                if (color == "blue") console.ConsoleColor = Color.Blue;
                if (color == "yellow") console.ConsoleColor = Color.Yellow;
                if (color == "green") console.ConsoleColor = Color.Green;
                if (color == "orange") console.ConsoleColor = Color.Orange;
                if (color == "purple") console.ConsoleColor = Color.Purple;
                if (color == "black") console.ConsoleColor = Color.Black;
                if (color == "white") console.ConsoleColor = Color.White;
                if (string.IsNullOrEmpty(color)) console.ConsoleColor = Color.Black;
            }

            commandAction(null);
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }
    }
}
