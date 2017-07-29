using LD39.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LD39.Entity
{
    public class Console : Entity
    {
        public Rectangle Screen { get; set; }

        public bool CursorBlink { get; set; } = false;
        public int CurrentCursorBlinkTime { get; set; } = 0;

        public int CursorBlinkingSpeed { get; set; } = 500;
        public char CursorCharacter { get; set; } = '_';
        public Vector2 CursorPosition { get; set; } = new Vector2(0f, 0f);

        public List<string> ConsoleLog = new List<string>();
        public Color ConsoleTextColor { get; set; } = Color.White;
        public Color ConsoleColor { get; set; } = Color.Black;
        public SpriteFont ConsoleFont { get; set; }

        public Console(Vector2 position, Texture2D texture, SpriteFont font) : base(position, texture)
        {
            ConsoleFont = font;
            Screen = new Rectangle((int)Position.X, (int)Position.Y, 1280 / 2, 720);
        }

        public override void Init()
        {
            ConsoleLog.Add("Hello");
            ConsoleLog.Add("World");
            ConsoleLog.Add("Lorem");
            ConsoleLog.Add("Ipsum");
            ConsoleLog.Add("Stuff");
            ConsoleLog.Add("Random");
            ConsoleLog.Add("Computer");
            ConsoleLog.Add("Power");
            ConsoleLog.Add("Ludum Dare");
        }

        public override void Update(GameTime gametime)
        {
            //throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(Texture, Screen, ConsoleColor);

            for (int i = 0; i < ConsoleLog.Count; i++)
            {
                string LogLine = ConsoleLog[i];

                if (CursorBlink && CursorPosition.Y == i)
                {
                    LogLine = ConsoleLog[i].ReplaceAt((int)CursorPosition.X, CursorCharacter);
                }

                batch.DrawString(ConsoleFont, LogLine, new Vector2(10, 10 + 32 * i), ConsoleTextColor);
            }

            batch.End();
        }

    }
}
