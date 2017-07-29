using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD39.Entity
{
    public class Console : Entity
    {
        public Rectangle Screen { get; set; }

        public Console(Vector2 position, Texture2D texture) : base(position, texture)
        {
            Screen = new Rectangle((int)Position.X, (int)Position.Y, 1280 / 2, 720);
        }

        public override void Init()
        {

        }

        public override void Update(GameTime gametime)
        {
            //throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(Texture, Screen, Color.Black);
            batch.End();
        }


    }
}
