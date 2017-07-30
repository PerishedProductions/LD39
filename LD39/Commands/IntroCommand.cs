using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.Commands
{
    public class IntroCommand : Command
    {
        public IntroCommand(Action<List<string>> commandCallback) : base(commandCallback)
        {
            Name = "intro";
        }

        public override void DisplayHelp()
        {
            feedback.Add("If you cant remember what your client pays you to do, you can use this command to show the intro again");
            commandAction(feedback);
        }

        public override void DisplayUsage()
        {
            feedback.Add("Simply type 'intro' into the console, and tadaaa...");
            commandAction(feedback);
        }

        public override bool HasRequiredArguments(Dictionary<string, string> arguments)
        {
            return false;
        }

        public override void PerformCommandWithArguments(Dictionary<string, string> arguments)
        {
            
        }

        public override void PerformCommandWithoutArguments()
        {
            feedback.Add("MS-HACK V.001 - Enterprise edition");
            feedback.Add("                                  ");
            feedback.Add("You have one new mail:");
            feedback.Add("                                  ");
            feedback.Add("From: Anonymous");
            feedback.Add("To: xXhackerKidXx@hacker.com");
            feedback.Add("----------------------------------");
            feedback.Add("Hello Hacker Kid, i heard you are the best hacker on the planet!");
            feedback.Add("For some reason i am really mad at duck island. I want you to cause a blackout on the whole island.");
            feedback.Add("If you complete the task i will pay you 10 million dollars");
            feedback.Add("Best Regards: Some random dude that dosent like Duck Island");
            feedback.Add("----------------------------------");
            commandAction(feedback);
        }
    }
}
