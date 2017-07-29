using Comora;
using LD39.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD39.GameStates
{
    public class PlayingState : GameState
    {

        private SpriteFont fnt;
        private Texture2D bg;
        private Texture2D map;
<<<<<<< HEAD
        private Camera cam;
=======

        private Console console;
>>>>>>> b90c6d44a57f66438a1ca47d000e4a0d90bbff40

        public override void Init()
        {
            cam = new Camera(game.GraphicsDevice);
            cam.LoadContent(game.GraphicsDevice);
            cam.Scale = 2;

            fnt = game.Content.Load<SpriteFont>("Fonts/fnt");
            bg = game.Content.Load<Texture2D>("Sprites/BlackBox");
            map = game.Content.Load<Texture2D>("Sprites/Island");

            console = new Console(new Vector2(0, 0), bg, fnt);
            console.Init();
        }

        public override void Update(GameTime gameTime)
        {
            console.Update(gameTime);
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin(cam, SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            batch.Draw(map, new Vector2(-25, -180), Color.White);
            batch.Draw(bg, new Rectangle(0, 0, 500, 500), new Color(0, 0, 0, 0.5f));
            batch.End();

<<<<<<< HEAD
            batch.Begin();
            batch.Draw(bg, new Rectangle(0, 0, 1280 / 2, 720), Color.Black);
            batch.DrawString(fnt, "-- Duck Island --", new Vector2(1280 - 445, 50), Color.White);
            batch.DrawString(fnt, "> run hacker.exe", new Vector2(20, 720 - 52), Color.Green);
            batch.End();
=======
            console.Draw(batch);
>>>>>>> b90c6d44a57f66438a1ca47d000e4a0d90bbff40
        }
    }
}
