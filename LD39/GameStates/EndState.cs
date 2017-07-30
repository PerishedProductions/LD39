using LD39.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.GameStates
{
    class EndState : GameState
    {
        private SpriteFont fnt;
        private SpriteFont bigFnt;

        private string header = "You Win!";
        private string madeByStr = "Congratulation you successfully shut down whole Duck Island";
        private int headerLength;
        private int enterToStartLength;
        private int madeByLength;

        public override void Init()
        {
            fnt = game.Content.Load<SpriteFont>("Fonts/fnt");
            bigFnt = game.Content.Load<SpriteFont>("Fonts/bigFnt");

            headerLength = (int)bigFnt.MeasureString(header).X;
            enterToStartLength = (int)fnt.MeasureString("Press 'enter' to go back to main menu...").X;
            madeByLength = (int)fnt.MeasureString(madeByStr).X;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            batch.DrawString(bigFnt, header, new Vector2(1280 / 2 - headerLength / 2, 200), Color.White);
            batch.DrawString(fnt, "Press 'enter' to go back to main menu...", new Vector2(1280 / 2 - enterToStartLength / 2, 200 + 120), Color.White);
            batch.DrawString(fnt, madeByStr, new Vector2(1280 / 2 - madeByLength / 2, 200 + 70), Color.White);

            if (InputManager.Instance.isPressed(Keys.Enter))
            {
                game.PopState();
            }

            batch.End();
        }
    }
}
