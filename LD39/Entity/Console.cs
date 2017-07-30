using LD39.Commands;
using LD39.Managers;
using LD39.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Vector2 CursorPosition { get; set; } = new Vector2(0, 0);

        public List<string> ConsoleLog = new List<string>();
        public Color ConsoleTextColor { get; set; } = Color.White;
        public Color ConsoleColor { get; set; } = Color.Black;
        public SpriteFont ConsoleFont { get; set; }

        public int ConsoleTopLogLine { get; set; } = 0;
        public int ConsoleLogMaxVisibleLines { get; set; } = 29;
        public int ConsoleMaxLines { get; set; } = 100;
        public int ConsoleLineWidth { get; set; } = 40;

        private const string ConsoleStartCharacter = ">";
        private bool ConsoleLocked = false;

        private SoundEffect click1;
        private SoundEffect click2;

        public Console(Vector2 position, Texture2D texture, SpriteFont font, SoundEffect click1, SoundEffect click2) : base(position, texture)
        {
            ConsoleFont = font;
            Screen = new Rectangle((int)Position.X, (int)Position.Y, 1280 / 2, 720);
            this.click1 = click1;
            this.click2 = click2;
        }

        public override void Init()
        {
            commandManager = new CommandManager(AddLinesToConsole);
            commandManager.Init(this);
            Reset();
        }

        #region CursorHelperFunctions

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

                if (line.StartsWith(ConsoleStartCharacter))
                {
                    CursorPosition = CursorPosition - new Vector2(CursorPosition.X - 1, 0);
                }
                else
                {
                    CursorPosition = CursorPosition - new Vector2(CursorPosition.X, 0);
                }
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
            string currentLine = ConsoleLog[(int)CursorPosition.Y];

            if (currentLine.StartsWith(ConsoleStartCharacter))
            {
                if (CursorPosition.X == 1)
                {
                    if (MoveCursorUp())
                    {
                        currentLine = ConsoleLog[(int)CursorPosition.Y];
                        CursorPosition = CursorPosition + new Vector2(currentLine.Length - 2, 0);
                        return true;
                    }

                    return false;
                }
            }
            else
            {
                if (CursorPosition.X == 0)
                {
                    if (MoveCursorUp())
                    {
                        currentLine = ConsoleLog[(int)CursorPosition.Y];
                        CursorPosition = CursorPosition + new Vector2(currentLine.Length - 2, 0);
                        return true;
                    }

                    return false;
                }
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
                    currentLine = ConsoleLog[(int)CursorPosition.Y];

                    if (currentLine.StartsWith(ConsoleStartCharacter))
                    {
                        CursorPosition = CursorPosition - new Vector2(CursorPosition.X - 1, 0);
                    }
                    else
                    {
                        CursorPosition = CursorPosition - new Vector2(CursorPosition.X, 0);
                    }

                    return true;
                }

                return false;
            }

            CursorPosition = CursorPosition + new Vector2(1, 0);
            return true;
        }

        #endregion

        #region ConsoleInteraction

        private void WriteLetters()
        {
            bool shift = input.isDown(Keys.LeftShift) || input.isDown(Keys.RightShift);

            #region Alphanumeric

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

            if (input.isPressed(Keys.D0)) if (shift) WriteLetter(")"); else WriteLetter("0");
            if (input.isPressed(Keys.D1)) if (shift) WriteLetter("!"); else WriteLetter("1");
            if (input.isPressed(Keys.D2)) if (shift) WriteLetter("@"); else WriteLetter("2");
            if (input.isPressed(Keys.D3)) if (shift) WriteLetter("#"); else WriteLetter("3");
            if (input.isPressed(Keys.D4)) if (shift) WriteLetter("$"); else WriteLetter("4");
            if (input.isPressed(Keys.D5)) if (shift) WriteLetter("%"); else WriteLetter("5");
            if (input.isPressed(Keys.D6)) if (shift) WriteLetter("^"); else WriteLetter("6");
            if (input.isPressed(Keys.D7)) if (shift) WriteLetter("&"); else WriteLetter("7");
            if (input.isPressed(Keys.D8)) if (shift) WriteLetter("*"); else WriteLetter("8");
            if (input.isPressed(Keys.D9)) if (shift) WriteLetter("("); else WriteLetter("9");

            #endregion

            #region Numpad

            if (input.isPressed(Keys.Decimal)) WriteLetter(".");
            if (input.isPressed(Keys.NumPad0)) WriteLetter("0");
            if (input.isPressed(Keys.NumPad1)) WriteLetter("1");
            if (input.isPressed(Keys.NumPad2)) WriteLetter("2");
            if (input.isPressed(Keys.NumPad3)) WriteLetter("3");
            if (input.isPressed(Keys.NumPad4)) WriteLetter("4");
            if (input.isPressed(Keys.NumPad5)) WriteLetter("5");
            if (input.isPressed(Keys.NumPad6)) WriteLetter("6");
            if (input.isPressed(Keys.NumPad7)) WriteLetter("7");
            if (input.isPressed(Keys.NumPad8)) WriteLetter("8");
            if (input.isPressed(Keys.NumPad9)) WriteLetter("9");

            if (input.isPressed(Keys.Space)) WriteLetter(" ");
            if (input.isPressed(Keys.Divide)) WriteLetter("/");
            if (input.isPressed(Keys.Multiply)) WriteLetter("*");
            if (input.isPressed(Keys.Subtract)) WriteLetter("-");
            if (input.isPressed(Keys.Add)) WriteLetter("+");

            #endregion

            #region Specials

            if (input.isPressed(Keys.OemPlus)) if (shift) WriteLetter("+"); else WriteLetter("=");
            if (input.isPressed(Keys.OemPeriod)) if (shift) WriteLetter(">"); else WriteLetter(".");
            if (input.isPressed(Keys.OemMinus)) if (shift) WriteLetter("_"); else WriteLetter("-");
            if (input.isPressed(Keys.OemComma)) if (shift) WriteLetter("<"); else WriteLetter(",");
            if (input.isPressed(Keys.OemCloseBrackets)) if (shift) WriteLetter("}"); else WriteLetter("]");
            if (input.isPressed(Keys.OemOpenBrackets)) if (shift) WriteLetter("{"); else WriteLetter("[");
            if (input.isPressed(Keys.OemPipe)) if (shift) WriteLetter("|"); else WriteLetter("\\");
            if (input.isPressed(Keys.OemQuestion)) if (shift) WriteLetter("?"); else WriteLetter("/");
            if (input.isPressed(Keys.OemQuotes)) if (shift) WriteLetter("\""); else WriteLetter("\'");
            if (input.isPressed(Keys.OemSemicolon)) if (shift) WriteLetter(":"); else WriteLetter(";");
            if (input.isPressed(Keys.OemBackslash)) if (shift) WriteLetter("|"); else WriteLetter("\\");
            if (input.isPressed(Keys.OemTilde)) if (shift) WriteLetter("~"); else WriteLetter("`");

            #endregion
        }

        private void WriteLetter(string letter)
        {
            string line = ConsoleLog[ConsoleLog.Count - 1];

            if (line.Length < ConsoleLineWidth)
            {
                line = line.Insert((int)CursorPosition.X, letter);
                ConsoleLog[ConsoleLog.Count - 1] = line;

                MoveCursorRight();

                Random rng = new Random();
                int randNum = rng.Next(0, 2);

                if (randNum > 0.5)
                {
                    click1.Play();
                }
                else if (randNum < 0.5)
                {
                    click2.Play();
                }
            }
        }

        private void ConfirmCommand(bool IgnoreKeyPress = false)
        {
            if (input.isPressed(Keys.Enter) || IgnoreKeyPress)
            {
                ConsoleLocked = true;

                string line = ConsoleLog[ConsoleLog.Count - 1];

                CursorPosition = new Vector2(1, CursorPosition.Y);

                if (line.EndsWith(" ", StringComparison.InvariantCultureIgnoreCase))
                {
                    line = line.Remove(line.Length - 1);
                }

                ConsoleLog[ConsoleLog.Count - 1] = line;

                if (line.StartsWith(ConsoleStartCharacter))
                {
                    line = line.Remove(0, 1);
                }

                string[] argumentsList = line.Split(' ');
                string command = argumentsList[0];
                Dictionary<string, string> argumentDict = new Dictionary<string, string>();
                for (int i = 1; i < argumentsList.Length; i++)
                {
                    char[] seperator = { '=' };
                    string[] argument = argumentsList[i].Split(seperator, 2);

                    if (argument.Count() > 1)
                    {
                        argumentDict.Add(argument[0], argument[1]);
                    }
                    else
                    {
                        argumentDict.Add(argument[0], null);
                    }
                }

                commandManager.ParseCommand(command, argumentDict);

                ConsoleLocked = false;
            }
        }

        private void RemoveLetters()
        {
            if (input.isPressed(Keys.Delete))
            {
                string line = ConsoleLog[ConsoleLog.Count - 1];

                if (line.Length > 2 && line.Length - CursorPosition.X > 1)
                {
                    line = line.Remove((int)CursorPosition.X, 1);
                    ConsoleLog[ConsoleLog.Count - 1] = line;
                }
            }

            if (input.isPressed(Keys.Back))
            {
                string line = ConsoleLog[ConsoleLog.Count - 1];

                if (line.Length > 2 && line.Length - CursorPosition.X > 0 && CursorPosition.X > 1)
                {
                    line = line.Remove((int)CursorPosition.X - 1, 1);
                    ConsoleLog[ConsoleLog.Count - 1] = line;
                    MoveCursorLeft();
                }
            }
        }

        public void AddLinesToConsole(List<string> messages)
        {
            if (messages != null)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    AddMessageToConsole(messages[i].ToLowerInvariant());
                }
            }

            AddMessageToConsole(string.Concat(ConsoleStartCharacter, " "));
        }

        private void AddMessageToConsole(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                ConsoleLog.Add(message);

                if (ConsoleLog.Count > ConsoleMaxLines)
                {
                    for (int j = 0; j < ConsoleLog.Count - ConsoleMaxLines; j++)
                    {
                        ConsoleLog.RemoveAt(0);
                    }
                }

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

                        if (ConsoleLog.Count > ConsoleMaxLines)
                        {
                            for (int j = 0; j < ConsoleLog.Count - ConsoleMaxLines; j++)
                            {
                                ConsoleLog.RemoveAt(0);
                            }
                        }

                        MoveCursorDown();
                    }

                    consoleLine = messages[i];
                }

                if (i == messages.Length - 1)
                {
                    if (!string.IsNullOrEmpty(consoleLine))
                    {
                        ConsoleLog.Add(consoleLine);

                        if (ConsoleLog.Count > ConsoleMaxLines)
                        {
                            for (int j = 0; j < ConsoleLog.Count - ConsoleMaxLines; j++)
                            {
                                ConsoleLog.RemoveAt(0);
                            }
                        }

                        MoveCursorDown();
                    }
                }
            }
        }

        #endregion

        #region ConsoleHelperFunctions

        public void Clear()
        {
            ConsoleLog.Clear();
            AddMessageToConsole(string.Concat(ConsoleStartCharacter, " "));
            ConsoleTopLogLine = 0;
            CursorPosition = new Vector2(1, 0);
        }

        public void Reset()
        {
            ConsoleTextColor = Color.White;
            ConsoleColor = Color.Black;
            Clear();
        }

        private bool IsCursorAtConsoleEnd()
        {
            return CursorPosition.Y == ConsoleTopLogLine + ConsoleLogMaxVisibleLines - 1;
        }

        private bool IsCursorAtLogEnd()
        {
            return CursorPosition.Y == ConsoleLog.Count - 1;
        }

        #endregion


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
                if (!ConsoleLocked)
                {
                    WriteLetters();
                    RemoveLetters();
                    ConfirmCommand();
                }
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
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

                batch.DrawString(ConsoleFont, LogLine, new Vector2(10, 10 + 24 * i), ConsoleTextColor);
            }

            batch.DrawString(ConsoleFont, string.Concat("X:", CursorPosition.X, " Y:", CursorPosition.Y.ToString()), new Vector2(500, 10), Color.Green);

            batch.End();
        }

    }
}
