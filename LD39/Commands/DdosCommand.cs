using LD39.Entity;
using LD39.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LD39.Commands
{
    public class DdosCommand : Command
    {
        private GameManager gm = GameManager.Instance;

        public DdosCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "ddos";
        }

        public override void DisplayHelp()
        {
            feedback.Add("The ddos command allows you to trigger a ddos attack on a target.");
            feedback.Add("The target may resist attacks based on how well protected it is against ddos attacks.");
            feedback.Add("This may be dealt with by increasing your botnetwork strength or by decreasing the targets resistance.");

            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: ddos -ip [-b]");
            feedback.Add("Required argument: -ip");
            feedback.Add("ip is used as a target destination for the ddos and requires an ip address as value.");
            feedback.Add("Optional argument: -b or -bots");
            feedback.Add("Allows you to specify how big the ddos attack should be.");
            feedback.Add("Note that you can not use more bots than you have available in your network.");

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

            City city = gm.cities.Find((c) => c.IP == ip);

            if (city == null || ip != city?.IP)
            {
                feedback.Add($"Unable to perform DDOS. Reason: Server with IP-address not found. IP-address={ip}");
                commandAction(feedback);
                return;
            }

            if (city.HasDDOSProtection)
            {
                feedback.Add("City has DDOS protection. DDOS Attack failed");
                commandAction(feedback);
                return;
            }

            int totalBots = gm.cities.Sum((c) => c.Bots);

            actualBotCount = totalBots < requestedBotCount ? totalBots : requestedBotCount;

            if (actualBotCount == 0)
            {
                feedback.Add($"City is unable to be DDOSed. Reason: No bots available to generate load.");
                commandAction(feedback);
            }
            else if (city.DDOSTreshold > actualBotCount)
            {
                feedback.Add($"City was DDOSed but it was able to withstand the load. bots used for attack={actualBotCount}");
                feedback.Add("Bots used is either the requested amount or all bots that are available.");
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
