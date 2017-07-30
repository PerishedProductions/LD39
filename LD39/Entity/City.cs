using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD39.Entity
{
    public class City : Entity
    {
        private static Random rng = new Random();

        public enum Versions
        {
            Version1,
            Version2,
            Version3,
            Version4,
            Version5
        }

        public bool IsAntiVirusActive { get; set; } = true;
        public Versions AntiVirusVersion { get; set; } = Versions.Version1;

        public bool HasDDOSProtection
        {
            get
            {
                return DDOSTreshold > Citizens - Citizens * 0.1;
            }
        }
        public int DDOSTreshold { get; set; } = 5000;
        public int Citizens { get; set; } = 10000;
        public int Bots { get; set; } = 0;
        public string IP { get; set; }
        public string Name { get; set; } = "Derpington";

        public bool IsCityActive { get; set; } = true;


        public City(Vector2 position, Texture2D texture) : base(position, texture)
        {

        }

        public override void Init()
        {
            IP = string.Concat(rng.Next(255), ".", rng.Next(255), ".", rng.Next(255), ".", rng.Next(255));
            Citizens = rng.Next(1000, 10000000);
            DDOSTreshold = rng.Next(0, (int)(Citizens * 1.5));
            AntiVirusVersion = (Versions)rng.Next(0, Enum.GetNames(typeof(Versions)).Length);
            IsAntiVirusActive = rng.Next(0, 5) != 0;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
