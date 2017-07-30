using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LD39.Managers;
using Microsoft.Xna.Framework.Input;

namespace LD39.GameStates
{
    public class MenuState : GameState
    {

        private SpriteFont fnt;
        private SpriteFont bigFnt;

        private string header = "GAME TITLE";
        private string madeByStr = "Programming: Dragion, Cobo. Art & Music: Cobo. Project Managment: Trux.";
        private int headerLength;
        private int enterToStartLength;
        private int madeByLength;

        public override void Init()
        {
            fnt = game.Content.Load<SpriteFont>("Fonts/fnt");
            bigFnt = game.Content.Load<SpriteFont>("Fonts/bigFnt");

            headerLength = (int)bigFnt.MeasureString(header).X;
            enterToStartLength = (int)fnt.MeasureString("Press 'enter' to start...").X;
            madeByLength = (int)fnt.MeasureString(madeByStr).X;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            batch.DrawString(bigFnt, header, new Vector2(1280 / 2 - headerLength / 2, 200), Color.White);
            batch.DrawString(fnt, "Press 'enter' to start...", new Vector2(1280 / 2 - enterToStartLength / 2, 200 + 70), Color.White);
            batch.DrawString(fnt, madeByStr, new Vector2(1280 / 2 - madeByLength / 2, 600), Color.White);

            if (InputManager.Instance.isPressed(Keys.Enter))
            {
                PlayingState newState = new PlayingState();
                newState.game = game;
                game.PushState(newState);
            }

            batch.End();
        }

    }
}
