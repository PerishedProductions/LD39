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
        public int ConsoleMaxLines { get; set; } = 100;

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
            ConsoleLog.Add(" ");
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
            UpdateInput();
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

        private void UpdateInput()
        {
            if (input.isPressed(Keys.Q)) WriteLetter("Q");
            if (input.isPressed(Keys.W)) WriteLetter("W");
            if (input.isPressed(Keys.E)) WriteLetter("E");
            if (input.isPressed(Keys.R)) WriteLetter("R");
            if (input.isPressed(Keys.T)) WriteLetter("T");
            if (input.isPressed(Keys.Y)) WriteLetter("Y");
            if (input.isPressed(Keys.U)) WriteLetter("U");
            if (input.isPressed(Keys.I)) WriteLetter("I");
            if (input.isPressed(Keys.O)) WriteLetter("O");
            if (input.isPressed(Keys.P)) WriteLetter("P");
            if (input.isPressed(Keys.A)) WriteLetter("A");
            if (input.isPressed(Keys.S)) WriteLetter("S");
            if (input.isPressed(Keys.D)) WriteLetter("D");
            if (input.isPressed(Keys.F)) WriteLetter("F");
            if (input.isPressed(Keys.G)) WriteLetter("G");
            if (input.isPressed(Keys.H)) WriteLetter("H");
            if (input.isPressed(Keys.J)) WriteLetter("J");
            if (input.isPressed(Keys.K)) WriteLetter("K");
            if (input.isPressed(Keys.L)) WriteLetter("L");
            if (input.isPressed(Keys.Z)) WriteLetter("Z");
            if (input.isPressed(Keys.X)) WriteLetter("X");
            if (input.isPressed(Keys.C)) WriteLetter("C");
            if (input.isPressed(Keys.V)) WriteLetter("V");
            if (input.isPressed(Keys.B)) WriteLetter("B");
            if (input.isPressed(Keys.N)) WriteLetter("N");
            if (input.isPressed(Keys.M)) WriteLetter("M");

            if (input.isPressed(Keys.D0) || input.isPressed(Keys.NumPad0)) WriteLetter("0");
            if (input.isPressed(Keys.D1) || input.isPressed(Keys.NumPad1)) WriteLetter("1");
            if (input.isPressed(Keys.D2) || input.isPressed(Keys.NumPad2)) WriteLetter("2");
            if (input.isPressed(Keys.D3) || input.isPressed(Keys.NumPad3)) WriteLetter("3");
            if (input.isPressed(Keys.D4) || input.isPressed(Keys.NumPad4)) WriteLetter("4");
            if (input.isPressed(Keys.D5) || input.isPressed(Keys.NumPad5)) WriteLetter("5");
            if (input.isPressed(Keys.D6) || input.isPressed(Keys.NumPad6)) WriteLetter("6");
            if (input.isPressed(Keys.D7) || input.isPressed(Keys.NumPad7)) WriteLetter("7");
            if (input.isPressed(Keys.D8) || input.isPressed(Keys.NumPad8)) WriteLetter("8");
            if (input.isPressed(Keys.D9) || input.isPressed(Keys.NumPad9)) WriteLetter("9");

            if (input.isPressed(Keys.OemPeriod)) WriteLetter(".");
            if (input.isPressed(Keys.OemPlus)) WriteLetter("+");
            if (input.isPressed(Keys.OemMinus)) WriteLetter("-");
            if (input.isPressed(Keys.OemComma)) WriteLetter(",");
            if (input.isPressed(Keys.Space)) WriteLetter(" ");
            if (input.isPressed(Keys.Divide)) WriteLetter("/");
            if (input.isPressed(Keys.Multiply)) WriteLetter("*");
            if (input.isPressed(Keys.OemBackslash)) WriteLetter("\\");


            if (input.isPressed(Keys.Delete))
            {

            }

            if (input.isPressed(Keys.Enter))
            {

            }

            if (input.isPressed(Keys.Back))
            {

            }
        }

        private void WriteLetter(string letter)
        {
            if (CursorPosition.Y == ConsoleTopLogLine + ConsoleLogMaxVisibleLines - 1)
            {
                string line = ConsoleLog[ConsoleLog.Count - 1];

                line = line.Insert((int)CursorPosition.X, letter);
                ConsoleLog[ConsoleLog.Count - 1] = line;

                MoveCursorRight();
            }
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
