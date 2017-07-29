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

        public int ConsoleTopLogLine { get; set; } = 0;
        public int ConsoleLogMaxVisibleLines { get; set; } = 20;

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
            ConsoleLog.Add("Hello2");
            ConsoleLog.Add("World2");
            ConsoleLog.Add("Lorem2");
            ConsoleLog.Add("Ipsum2");
            ConsoleLog.Add("Stuff2");
            ConsoleLog.Add("Random2");
            ConsoleLog.Add("Computer2");
            ConsoleLog.Add("Power2");
            ConsoleLog.Add("Ludum Dare2");
            ConsoleLog.Add("Hello3");
            ConsoleLog.Add("World3");
            ConsoleLog.Add("Lorem3");
            ConsoleLog.Add("Ipsum3");
            ConsoleLog.Add("Stuff3");
            ConsoleLog.Add("Random3");
            ConsoleLog.Add("Computer3");
            ConsoleLog.Add("Power3");
            ConsoleLog.Add("Ludum Dare3");
        }

        public override void Update(GameTime gameTime)
        {
            CurrentCursorBlinkTime += gameTime.ElapsedGameTime.Milliseconds;

            if (CurrentCursorBlinkTime > CursorBlinkingSpeed)
            {
                CurrentCursorBlinkTime = 0;
                CursorBlink = !CursorBlink;
            }

            UpdateCursorPosition();
        }

        private void UpdateCursorPosition()
        {
            if (input.isPressed(Keys.Left))
            {
                MoveCursorLeft();
            }

            if (input.isPressed(Keys.Right))
            {
                MoveCursorRight();
            }

            if (input.isPressed(Keys.Down))
            {
                MoveCursorDown();
            }

            if (input.isPressed(Keys.Up))
            {
                MoveCursorUp();
            }
        }
        private bool MoveCursorUp()
        {
            if (CursorPosition.Y == ConsoleTopLogLine)
            {
                if (CursorPosition.Y == 0)
                {
                    return false;
                }

                ConsoleTopLogLine--;
            }

            CursorPosition = CursorPosition - new Vector2(0, 1);


            string currentLine = ConsoleLog[(int)CursorPosition.Y];
            if (CursorPosition.X >= currentLine.Length)
            {
                CursorPosition = new Vector2(currentLine.Length - 1, CursorPosition.Y);
            }

            return true;
        }
        private bool MoveCursorDown()
        {
            if (CursorPosition.Y == ConsoleTopLogLine + ConsoleLogMaxVisibleLines - 1)
            {
                if (CursorPosition.Y >= ConsoleLog.Count - 1)
                {
                    return false;
                }

                ConsoleTopLogLine++;
            }

            CursorPosition = CursorPosition + new Vector2(0, 1);

            string currentLine = ConsoleLog[(int)CursorPosition.Y];

            if (CursorPosition.X >= currentLine.Length)
            {
                CursorPosition = new Vector2(currentLine.Length - 1, CursorPosition.Y);
            }

            return true;
        }
        private bool MoveCursorLeft()
        {
            if (CursorPosition.X == 0)
            {
                if (MoveCursorUp())
                {
                    string currentLine = ConsoleLog[(int)CursorPosition.Y];

                    CursorPosition = CursorPosition + new Vector2(currentLine.Length - 1, 0);
                    return true;
                }

                return false;
            }

            CursorPosition = CursorPosition - new Vector2(1, 0);
            return true;
        }
        private bool MoveCursorRight()
        {
            string currentLine = ConsoleLog[(int)CursorPosition.Y];

            if (CursorPosition.X >= currentLine.Length - 1)
            {
                if (MoveCursorDown())
                {
                    CursorPosition = CursorPosition - new Vector2(CursorPosition.X, 0);
                    return true;
                }

                return false;
            }


            CursorPosition = CursorPosition + new Vector2(1, 0);
            return true;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(Texture, Screen, ConsoleColor);

            for (int i = 0; i < ConsoleLogMaxVisibleLines; i++)
            {
                if (i + ConsoleTopLogLine >= ConsoleLog.Count)
                {
                    break;
                }

                string LogLine = ConsoleLog[ConsoleTopLogLine + i];

                if (CursorBlink && CursorPosition.Y == ConsoleTopLogLine + i)
                {
                    LogLine = LogLine.ReplaceAt((int)CursorPosition.X, CursorCharacter);
                }

                batch.DrawString(ConsoleFont, LogLine, new Vector2(10, 10 + 32 * i), ConsoleTextColor);
            }

            batch.DrawString(ConsoleFont, string.Concat("X:", CursorPosition.X, " Y:", CursorPosition.Y.ToString()), new Vector2(500, 10), Color.Green);

            batch.End();
        }

    }
}
