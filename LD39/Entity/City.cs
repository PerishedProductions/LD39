using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD39.Entity
{
    public class City : Entity
    {
        public enum Versions
        {
            Version1,
            Version2,
            Version3,
            Version4,
            Version5
        }

        public Versions OSVersion { get; set; } = Versions.Version1;
        public Versions AntiVirusVersion { get; set; } = Versions.Version1;
        public Versions MalwareVersion { get; set; } = Versions.Version1;

        public bool HasDDOSProtection { get; set; } = false;
        public int DDOSTreshold { get; set; } = 5000;
        public int Citizens { get; set; } = 10000;
        public int Bots { get; set; } = 7500;
        public string IP { get; set; } = "1.2.3.4";

        public string AdminAccount { get; set; } = "admin";
        public string AdminPass { get; set; } = "admin";
        public string UserAccount { get; set; } = "user";
        public string UserPass { get; set; } = "user";

        public bool IsAdminLoggedIn { get; set; } = false;
        public bool IsUserLoggedIn { get; set; } = false;

        public bool IsCityActive { get; set; } = true;


        public City(Vector2 position, Texture2D texture) : base(position, texture)
        {

        }

        public override void Init()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
