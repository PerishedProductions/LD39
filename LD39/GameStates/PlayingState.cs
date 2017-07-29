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

        private Console console;

        public override void Init()
        {
            cam = new Camera(game.GraphicsDevice);
            cam.LoadContent(game.GraphicsDevice);
            cam.Scale = 2;

            fnt = game.Content.Load<SpriteFont>("Fonts/fnt");
            bg = game.Content.Load<Texture2D>("Sprites/BlackBox");
            map = game.Content.Load<Texture2D>("Sprites/Island");

            console = new Console(new Vector2(0, 0), bg);
        }

        public override void Update(GameTime gameTime)
        {
            console.Update(gameTime);
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin(cam, SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            batch.Draw(map, new Vector2(-25, -180), Color.White);
            batch.End();

            console.Draw(batch);
        }
    }
}
