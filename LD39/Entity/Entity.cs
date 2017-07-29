using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD39.Entity
{
    public abstract class Entity
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public Entity(Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
        }

        public abstract void Init();
        public abstract void Update(GameTime gametime);

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(Texture, Position, Color.White);
            batch.End();
        }
    }
}
