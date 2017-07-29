using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD39.GameStates
{
    public class PlayingState : GameState
    {

        public SpriteFont fnt;

        public override void Init()
        {
            fnt = game.Content.Load<SpriteFont>("Fonts/fnt");
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.DrawString(fnt, "> run hacker.exe", new Vector2(20, 720 - 52), Color.Green);
            batch.End();
        }

    }
}
