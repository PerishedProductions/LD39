using LD39.Managers;
using LD39.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LD39.Entity
{
    public class Console : Entity
    {
        private InputManager input = InputManager.Instance;
        public Rectangle Screen { get; set; }

        public bool CursorBlink { get; set; } = false;
        public int CurrentCursorBlinkTime { get; set; } = 0;

        public int CursorBlinkingSpeed { get; set; } = 750;
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
            ConsoleLog.Add("Hello");
            ConsoleLog.Add("World");
            ConsoleLog.Add("Lorem");
            ConsoleLog.Add("Ipsum");
            ConsoleLog.Add("Stuff");
            ConsoleLog.Add("Random");
            ConsoleLog.Add("Computer");
            ConsoleLog.Add("Power");
            ConsoleLog.Add("Ludum Dare");
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

        public override void Update(GameTime gameTime)
        {
            CurrentCursorBlinkTime += gameTime.ElapsedGameTime.Milliseconds;

            if (CurrentCursorBlinkTime > CursorBlinkingSpeed)
            {
                CurrentCursorBlinkTime = 0;
                CursorBlink = !CursorBlink;
            }

            if (input.isPressed(Keys.Down))
            {
                CursorPosition = CursorPosition + new Vector2(0, 1);
            }

            if (input.isPressed(Keys.Up))
            {
                CursorPosition = CursorPosition - new Vector2(0, 1);
            }
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
