using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LD39.Entity
{
    public class Map : Entity
    {
        private Texture2D bigCity;
        private List<City> cities = new List<City>();


        public Map(Vector2 position, Texture2D texture, Texture2D bigCityTex) : base(position, texture)
        {
            bigCity = bigCityTex;
        }

        public override void Init()
        {
            cities.Add(new City(new Vector2(100, 50), bigCity));
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                cities[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch batch, Camera cam)
        {
            base.Draw(batch, cam);
            for (int i = 0; i < cities.Count; i++)
            {
                cities[i].Draw(batch, cam);
            }
        }


    }
}
