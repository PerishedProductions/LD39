using LD39.Entity;
using LD39.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using static LD39.Entity.City;

namespace LD39.Commands
{
    public class BackdoorCommand : Command
    {
        private GameManager gm = GameManager.Instance;
        private static Random rng = new Random();

        public BackdoorCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "backdoor";
        }

        public override void DisplayHelp()
        {
            feedback.Add("The backdoor command allows you to send backdoor attacks to various destinations.");
            feedback.Add("With the help of backdoors you are able to decrease the strength of cities.");
            feedback.Add("In turn this makes your attempts to hack stronger.");
            feedback.Add("It goes without saying, but backdoor attempts are typically not welcome.");

            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: backdoor -ip [-c] [-av] [-bot]");
            feedback.Add("Required argument: -ip");
            feedback.Add("The target destination the attack will be send to. The value is an ip-address");
            feedback.Add("Requires a secondary argument to specify what kind of backdoor attempt is being made.");
            feedback.Add("Semi Optional argument: -c or -check");
            feedback.Add("Check the software status of the target machine.");
            feedback.Add("Semi Optional argument: -av");
            feedback.Add("Attempt to shut down the anti virus software.");
            feedback.Add("Semi Optional argument: -bt or -bots or -threshold");
            feedback.Add("Attempt to decrease the resistane of the target to bot network attacks.");

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

            if (arguments.ContainsKey("-c") || arguments.ContainsKey("-check"))
            {
                DisplaySoftwareVersions(ip);
            }

            if (arguments.ContainsKey("-av"))
            {
                DropAntiVirus(ip);

            }

            if (arguments.ContainsKey("-bt") || arguments.ContainsKey("-bots") || arguments.ContainsKey("-threshold"))
            {
                DropCityBotTreshold(ip);
            }

            if (feedback.Any())
            {
                commandAction(feedback);
            }
            else
            {
                DisplayUsage();
            }
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }

        private void DisplaySoftwareVersions(string ip)
        {
            City city = gm.cities.Find((c) => c.IP == ip);

            if (city == null || ip != city?.IP)
            {
                feedback.Add($"Unable to retrieve backdoor info. Reason: Server with IP-address not found. IP-address={ip}");
                return;
            }

            if (city.IsAntiVirusActive && city.AntiVirusVersion >= Versions.Version4 && rng.Next(0, 1) != 0)
            {
                feedback.Add($"Unable to retrieve backdoor info. Reason: AntiVirus blocked attempt at data retrieval. IP-address={ip}");
                return;
            }

            feedback.Add($"-- AntiVirus software from server {ip} --");
            feedback.Add($"AntiVirus activated={city.IsAntiVirusActive}");
            feedback.Add($"AntiVirus version={city.AntiVirusVersion}");
        }

        private void DropCityBotTreshold(string ip)
        {
            City city = gm.cities.Find((c) => c.IP == ip);

            if (city == null || ip != city?.IP)
            {
                feedback.Add($"Unable to perform backdoor attack. Reason: Server with IP-address not found. IP-address={ip}");
                return;
            }

            if (city.IsAntiVirusActive && city.AntiVirusVersion >= Versions.Version3 && rng.Next(0, 3) != 0)
            {
                feedback.Add($"Unable to perform backdoor attack. Reason: AntiVirus blocked attempt at data access. IP-address={ip}");
                return;
            }

            if (city.DDOSTreshold > 0)
            {
                int ddosDrop = rng.Next(1, (int)(city.DDOSTreshold * 0.1));
                city.DDOSTreshold -= ddosDrop;
                feedback.Add($"Backdoor attack succesfull. Backdoor resistance on server has been lowered. Treshold decrease={ddosDrop} IP-address={ip}");
            }
            else
            {
                feedback.Add($"Backdoor attack succesfull. But the DDOSResistance can not be lowered any further. IP-address={ip}");
            }
        }

        private void DropAntiVirus(string ip)
        {
            City city = gm.cities.Find((c) => c.IP == ip);

            if (city == null || ip != city?.IP)
            {
                feedback.Add($"Unable to perform backdoor attack. Reason: Server with IP-address not found. IP-address={ip}");
                return;
            }

            if (city.IsAntiVirusActive && city.AntiVirusVersion >= Versions.Version2 && rng.Next(0, 2) != 0)
            {
                feedback.Add($"Unable to perform backdoor attack. Reason: AntiVirus blocked attempt at data access. IP-address={ip}");
                return;
            }

            city.IsAntiVirusActive = false;
            feedback.Add($"Backdoor attack succesfull. Antivirus software has been turned off. IP-address={ip}");
        }
    }
}
