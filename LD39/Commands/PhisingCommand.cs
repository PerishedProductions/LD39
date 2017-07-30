using LD39.Entity;
using LD39.Managers;
using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class PhisingCommand : Command
    {
        public PhisingCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "phis";
        }

        public override void DisplayHelp()
        {
            feedback.Add("TODO: Insert help here");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage of 'phis': -ip <destination ip address> -b");
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

            if (arguments.ContainsKey("-b") || arguments.ContainsKey("-bots"))
            {
                PerformBotPhising(ip);
                return;
            }

            commandAction(null);
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }

        private void PerformBotPhising(string ip)
        {
            GameManager gm = GameManager.Instance;

            City city = gm.cities.Find((c) => c.IP == ip);


            if (city == null || ip != city?.IP)
            {
                feedback.Add($"Unable to perform Phising. Reason: Server with IP-address not found. IP-address={ip}");
                commandAction(feedback);
                return;
            }

            if (city.Bots == city.Citizens)
            {
                feedback.Add($"Phising for bots not required. Reason: Every device has a bot installed. IP-address={ip}");
                commandAction(feedback);
                return;
            }

            Random rng = new Random();
            int randNum = rng.Next(0, 25);

            if (randNum == 0)
            {
                feedback.Add($"Phising for bots failed. Reason: No one failed for your trap");
                commandAction(feedback);
                return;
            }

            randNum = rng.Next(0, city.Citizens * randNum / 100);

            if (randNum == 0)
            {
                feedback.Add($"Phising for bots failed. Reason: No new devices found to install a bot");
                commandAction(feedback);
                return;
            }

            city.Bots = city.Bots + randNum <= city.Citizens ? city.Bots + randNum : city.Citizens;

            feedback.Add($"Phising for bots succesfull. Increase={randNum} Total bot count={city.Bots}. IP-address={ip}");
            commandAction(feedback);
        }
    }
}
