using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.GameStates
{
    public class GameState
    {
        public Game1 game;
        public Camera cam;

        public virtual void Init()
        {
            cam = new Camera(game.getGraphics());
            cam.LoadContent(game.GraphicsDevice);
            cam.Debug.IsVisible = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            cam.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Begin(cam);
            
            batch.End();
        }

    }
}
