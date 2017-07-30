using LD39.Entity;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class DdosCommand : Command
    {
        City city = new City(new Vector2(0, 0), null);

        public DdosCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "ddos";
        }

        public override void DisplayHelp()
        {
            feedback.Add("TODO: Insert help here");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("TODO: Insert usage here");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            return true;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            string value;
            if (arguments.TryGetValue("-b", out value) || arguments.TryGetValue("-bots", out value))
            {
                int botcount = 0;
                if (int.TryParse(value, out botcount))
                {
                    PerformDDOS(botcount);
                    return;
                }
                else
                {

                }
            }

            PerformDDOS();
        }

        public override void PerformCommandWithoutArguments()
        {
            PerformDDOS();
        }

        private void PerformDDOS(int requestedBotCount = 0)
        {
            int actualBotCount = 0;

            actualBotCount = city.Bots < requestedBotCount ? city.Bots : requestedBotCount;

            if (city.HasDDOSProtection)
            {
                feedback.Add("City has DDOS protection. DDOS Attack failed");
                commandAction(feedback);
            }
            else if (city.DDOSTreshold > actualBotCount)
            {
                feedback.Add("City was DDOSed but it was able to withstand the load.");
                commandAction(feedback);
            }
            else
            {
                city.IsCityActive = false;
                feedback.Add("City succesfully DDOSed");
                commandAction(feedback);
            }
        }
    }
}
