using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Comora;

namespace LD39.GameStates
{
    public class PlayingState : GameState
    {

        private SpriteFont fnt;
        private Texture2D bg;
        private Texture2D map;

        private Camera cam;

        public override void Init()
        {
            cam = new Camera(game.GraphicsDevice);
            cam.LoadContent(game.GraphicsDevice);
            cam.Scale = 2;

            fnt = game.Content.Load<SpriteFont>("Fonts/fnt");
            bg = game.Content.Load<Texture2D>("Sprites/BlackBox");
            map = game.Content.Load<Texture2D>("Sprites/Island");
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin(cam, SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            batch.Draw(map, new Vector2(-25, -180), Color.White);
            batch.End();

            batch.Begin();
            batch.Draw(bg, new Rectangle(0, 0, 1280 / 2, 720), Color.Black);
            batch.DrawString(fnt, "> run hacker.exe", new Vector2(20, 720 - 52), Color.Green);
            batch.End();
        }

    }
}
