using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD39.Entity
{
    public class Map : Entity
    {
        public Map(Vector2 position, Texture2D texture) : base(position, texture)
        {
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gametime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
