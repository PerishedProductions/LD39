using LD39.Entity;
using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class DdosCommand : Command
    {
        public City city { get; set; }

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
            feedback.Add("Usage of 'ddos': -ip <destination ip address> -b <bot count>");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-ip") && !string.IsNullOrEmpty(arguments["-ip"]))
            {
                return true;
            }

            return false;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            string ip = "127.0.0.1";

            ip = arguments["-ip"];

            string value;
            if (arguments.TryGetValue("-b", out value) || arguments.TryGetValue("-bots", out value))
            {
                int botcount = 0;
                if (int.TryParse(value, out botcount))
                {
                    PerformDDOS(ip, botcount);
                    return;
                }
                else
                {

                }
            }

            PerformDDOS(ip);
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }

        private void PerformDDOS(string ip, int requestedBotCount = 0)
        {
            int actualBotCount = 0;


            //TODO retrieve city based by IP
            if (ip != city?.IP)
            {
                feedback.Add($"Unable to perform DDOS. Reason: Server with IP-address not found. IP-address={ip}");
                commandAction(feedback);
                return;
            }

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
