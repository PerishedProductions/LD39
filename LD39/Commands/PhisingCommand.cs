using LD39.Entity;
using LD39.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LD39.Commands
{
    public class PhisingCommand : Command
    {
        private GameManager gm = GameManager.Instance;
        private static Random rng = new Random();

        public PhisingCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "phis";
        }

        public override void DisplayHelp()
        {
            feedback.Add("The phis command allows you to send phising messages to various destinations.");
            feedback.Add("With the help of phising you can retrieve data from unaware users.");
            feedback.Add("Perhaps you can also secure their device as a potential bot for your network.");

            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: phis -ip [-b]");
            feedback.Add("Required argument: -ip");
            feedback.Add("Ip is in 2 ways in combination with the -b argument.");
            feedback.Add(" - ip without a value will attempt to phis for IP addresses");
            feedback.Add(" - ip with a value will send phising mails to the destination.");
            feedback.Add("Requires a secondary argument to specify the data retrieved via phising.");
            feedback.Add("Semi Optional argument: -b or -bots");
            feedback.Add("Attempt to get more devices hooked up to your bot network via phising.");

            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-ip"))
            {
                return true;
            }

            return false;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            string ip = arguments["-ip"];

            if (!string.IsNullOrEmpty(ip))
            {
                if (arguments.ContainsKey("-b") || arguments.ContainsKey("-bots"))
                {
                    PerformBotPhising(ip);
                    return;
                }
                else
                {
                    DisplayUsage();
                    return;
                }
            }
            else
            {
                PerformIpPhising();
                return;
            }
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }

        private void PerformIpPhising()
        {
            int randNum = rng.Next(0, 10);

            if (randNum == 0)
            {
                feedback.Add("Attempt at IP phising has resulted into no results. Perhaps another try might lead to more information.");
                commandAction(feedback);
                return;
            }

            for (int i = 0; i < randNum; i++)
            {
                int succesfullChance = rng.Next(0, 100);

                if (succesfullChance <= 15)
                {
                    int cityNumber = rng.Next(0, gm.cities.Count);

                    City city = gm.cities[cityNumber];

                    feedback.Add($"* Attempt at phising found an IP-address:{city.IP}");

                }
            }

            if (feedback.Any())
            {
                feedback.Add($"Succesfully performed IP-Phising");
            }
            else
            {
                feedback.Add("Performed IP Phising with no results. Reason: Unfortunately by chance no one decided to fall for your traps.");
            }


            commandAction(feedback);
        }

        private void PerformBotPhising(string ip)
        {
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
