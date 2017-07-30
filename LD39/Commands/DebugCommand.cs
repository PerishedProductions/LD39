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
            feedback.Add("The debug command allows you to view / manipulate some background data.");
            feedback.Add("The debug command is normally hidden, but we left it in for the explorers.");

            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Usage: debug [i] [-c]");
            feedback.Add("Optional argument: -i or -init");
            feedback.Add("Regenerate the stats of the Cities");
            feedback.Add("Optional argument: -c or -cities");
            feedback.Add("Displays the information about all the cities");

            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-i") || arguments.ContainsKey("-init") || arguments.ContainsKey("-c") || arguments.ContainsKey("-cities"))
            {
                return true;
            }

            return false;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("-i") || arguments.ContainsKey("-init"))
            {
                ReInitializeCities();
            }

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

        private void ReInitializeCities()
        {
            List<City> cities = gm.cities;

            for (int i = 0; i < cities.Count; i++)
            {
                feedback.Add($"City {cities[i].Name} reinitialized.");
                cities[i].Init();
            }
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
                feedback.Add($"AntiVirusActive:{city.IsAntiVirusActive}");
                feedback.Add($"AntiVirusVersion:{city.AntiVirusVersion}");
                feedback.Add("---------------------");
            }
        }
    }
}
