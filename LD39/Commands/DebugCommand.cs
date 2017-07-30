using LD39.Entity;
using LD39.Managers;
using System;
using System.Collections.Generic;

namespace LD39.Commands
{
    public class DebugCommand : Command
    {
        private GameManager gm = GameManager.Instance;

        public DebugCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "debug";
            IsHidden = true;
        }

        public override void DisplayHelp()
        {
            feedback.Add("TODO: Insert help here");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage of 'debug': -c <cities>");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            return true;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-c") || arguments.ContainsKey("-cities"))
            {
                DisplayCityInformation();
            }

            commandAction(feedback);
        }

        public override void PerformCommandWithoutArguments()
        {
            DisplayUsage();
        }

        private void DisplayCityInformation()
        {
            List<City> cities = gm.cities;

            for (int i = 0; i < cities.Count; i++)
            {
                City city = cities[i];

                feedback.Add("-- City Information --");
                feedback.Add($"Name:{city.Name}");
                feedback.Add($"IP:{city.IP}");
                feedback.Add($"Population:{city.Citizens}");
                feedback.Add($"Bots:{city.Bots}");
                feedback.Add($"DDOSThreshold:{city.DDOSTreshold}");
                feedback.Add($"HasDDOSProtection:{city.HasDDOSProtection}");
                feedback.Add($"OSVersion:{city.OSVersion}");
                feedback.Add($"AntiVirusVersion:{city.AntiVirusVersion}");
                feedback.Add($"AntiMalwareVersion:{city.AntiMalwareVersion}");
                feedback.Add("---------------------");
            }
        }
    }
}
