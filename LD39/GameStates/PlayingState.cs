using Comora;
using LD39.Entity;
using LD39.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace LD39.GameStates
{
    public class PlayingState : GameState
    {

        private SpriteFont fnt;
        private Texture2D bg;
        private Texture2D mapSprite;
        private Texture2D circle;

        private Song isGut;

        private Console console;
        private Map map;

        public override void Init()
        {
            cam = new Camera(game.GraphicsDevice);
            cam.LoadContent(game.GraphicsDevice);
            cam.Scale = 2;

            fnt = game.Content.Load<SpriteFont>("Fonts/fnt");
            bg = game.Content.Load<Texture2D>("Sprites/BlackBox");
            mapSprite = game.Content.Load<Texture2D>("Sprites/Island");
            circle = game.Content.Load<Texture2D>("Sprites/Circle");
            isGut = game.Content.Load<Song>("Music/IsGut");

            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(isGut);

            console = new Console(new Vector2(0, 0), bg, fnt);
            console.Init();
            map = new Map(new Vector2(-25, -365 / 2), mapSprite, game.Content.Load<Texture2D>("Sprites/BigCity"));
            map.Init();
        }

        public override void Update(GameTime gameTime)
        {
            console.Update(gameTime);
        }

        public override void Draw(SpriteBatch batch)
        {
            map.Draw(batch, cam);
            console.Draw(batch);
        }
    }
}
