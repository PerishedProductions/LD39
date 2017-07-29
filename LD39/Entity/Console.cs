using LD39.Commands;
using LD39.Managers;
using LD39.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LD39.Entity
{
    public class Console : Entity
    {
        private CommandManager commandManager;
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
        public int ConsoleLineWidth { get; set; } = 40;

        public Console(Vector2 position, Texture2D texture, SpriteFont font) : base(position, texture)
        {
            ConsoleFont = font;
            Screen = new Rectangle((int)Position.X, (int)Position.Y, 1280 / 2, 720);
        }

        public override void Init()
        {
            commandManager = new CommandManager(AddLinesToConsole);
            commandManager.Init();
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

            if (IsCursorAtLogEnd())
            {
                WriteLetters();
                RemoveLetters();
                ConfirmCommand();
            }
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

            if (input.isPressed(Keys.Home))
            {
                string line = ConsoleLog[(int)CursorPosition.Y];
                CursorPosition = CursorPosition - new Vector2(CursorPosition.X, 0);
            }

            if (input.isPressed(Keys.End))
            {
                string line = ConsoleLog[(int)CursorPosition.Y];
                CursorPosition = CursorPosition + new Vector2(line.Length - 1 - CursorPosition.X, 0);
            }

            if (input.isPressed(Keys.PageUp))
            {
                for (int i = 0; i < ConsoleLogMaxVisibleLines; i++)
                {
                    MoveCursorUp();
                }
            }

            if (input.isPressed(Keys.PageDown))
            {
                for (int i = 0; i < ConsoleLogMaxVisibleLines; i++)
                {
                    MoveCursorDown();
                }
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
            if (CursorPosition.Y >= ConsoleLog.Count - 1)
            {
                return false;
            }

            if (CursorPosition.Y == ConsoleTopLogLine + ConsoleLogMaxVisibleLines - 1)
            {
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
        private void WriteLetters()
        {
            if (input.isPressed(Keys.Q)) WriteLetter("q");
            if (input.isPressed(Keys.W)) WriteLetter("w");
            if (input.isPressed(Keys.E)) WriteLetter("e");
            if (input.isPressed(Keys.R)) WriteLetter("r");
            if (input.isPressed(Keys.T)) WriteLetter("t");
            if (input.isPressed(Keys.Y)) WriteLetter("y");
            if (input.isPressed(Keys.U)) WriteLetter("u");
            if (input.isPressed(Keys.I)) WriteLetter("i");
            if (input.isPressed(Keys.O)) WriteLetter("o");
            if (input.isPressed(Keys.P)) WriteLetter("p");
            if (input.isPressed(Keys.A)) WriteLetter("a");
            if (input.isPressed(Keys.S)) WriteLetter("s");
            if (input.isPressed(Keys.D)) WriteLetter("d");
            if (input.isPressed(Keys.F)) WriteLetter("f");
            if (input.isPressed(Keys.G)) WriteLetter("g");
            if (input.isPressed(Keys.H)) WriteLetter("h");
            if (input.isPressed(Keys.J)) WriteLetter("j");
            if (input.isPressed(Keys.K)) WriteLetter("k");
            if (input.isPressed(Keys.L)) WriteLetter("l");
            if (input.isPressed(Keys.Z)) WriteLetter("z");
            if (input.isPressed(Keys.X)) WriteLetter("x");
            if (input.isPressed(Keys.C)) WriteLetter("c");
            if (input.isPressed(Keys.V)) WriteLetter("v");
            if (input.isPressed(Keys.B)) WriteLetter("b");
            if (input.isPressed(Keys.N)) WriteLetter("n");
            if (input.isPressed(Keys.M)) WriteLetter("m");

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
        }
        private void WriteLetter(string letter)
        {
            string line = ConsoleLog[ConsoleLog.Count - 1];

            line = line.Insert((int)CursorPosition.X, letter);
            ConsoleLog[ConsoleLog.Count - 1] = line;

            MoveCursorRight();

        }
        private void ConfirmCommand(bool IgnoreKeyPress = false)
        {
            if (input.isPressed(Keys.Enter) || IgnoreKeyPress)
            {
                string line = ConsoleLog[ConsoleLog.Count - 1];

                if (line.EndsWith(" ", StringComparison.InvariantCultureIgnoreCase))
                {
                    line = line.Remove(line.Length - 1);
                }

                ConsoleLog[ConsoleLog.Count - 1] = line;
                commandManager.ParseCommand(line);
            }
        }
        private void RemoveLetters()
        {
            if (input.isPressed(Keys.Delete))
            {
                string line = ConsoleLog[ConsoleLog.Count - 1];

                if (line.Length > 2 && line.Length - CursorPosition.X > 2)
                {
                    line = line.Remove((int)CursorPosition.X + 1, 1);
                    ConsoleLog[ConsoleLog.Count - 1] = line;
                }
            }

            if (input.isPressed(Keys.Back))
            {
                string line = ConsoleLog[ConsoleLog.Count - 1];

                if (line.Length > 1 && line.Length - CursorPosition.X > 0)
                {
                    line = line.Remove((int)CursorPosition.X - 1, 1);
                    ConsoleLog[ConsoleLog.Count - 1] = line;
                    MoveCursorLeft();
                }
            }
        }
        public void AddLinesToConsole(List<string> messages)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                AddMessageToConsole(messages[i].ToLowerInvariant());
            }

            AddMessageToConsole(" ");
        }
        private void AddMessageToConsole(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                ConsoleLog.Add(message);
                MoveCursorDown();
            }

            string[] messages = message.Split(' ');
            string consoleLine = "";
            for (int i = 0; i < messages.Length; i++)
            {
                if (consoleLine.Length + messages[i].Length <= ConsoleLineWidth)
                {
                    if (consoleLine.Length == 0)
                    {
                        consoleLine += messages[i];
                    }
                    else
                    {
                        consoleLine += " " + messages[i];
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(consoleLine))
                    {
                        ConsoleLog.Add(consoleLine);
                        MoveCursorDown();
                    }
                    consoleLine = "";
                }

                if (i == messages.Length - 1)
                {
                    if (!string.IsNullOrEmpty(consoleLine))
                    {
                        ConsoleLog.Add(consoleLine);
                        MoveCursorDown();
                    }
                }
            }
        }
        private bool IsCursorAtConsoleEnd()
        {
            return CursorPosition.Y == ConsoleTopLogLine + ConsoleLogMaxVisibleLines - 1;
        }
        private bool IsCursorAtLogEnd()
        {
            return CursorPosition.Y == ConsoleLog.Count - 1;
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
