using Comora;
using LD39.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace LD39.Managers
{
    public class GameManager
    {

        public static GameManager Instance { get; } = new GameManager();

        private GameManager() { }

        public Song mainSong { get; set; }
        public List<City> cities { get; set; }

        public void StartMusic()
        {
            if (mainSong != null)
            {
                MediaPlayer.Volume = 0.05f;
                MediaPlayer.Play(mainSong);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void StopMusic()
        {
            if (mainSong != null)
            {
                MediaPlayer.Stop();
            }
        }

        public void DrawCityUI(SpriteBatch batch, Camera cam, SpriteFont fnt)
        {
            for (int i = 0; i < cities.Count; i++)
            {

                int cityNameLength = (int)fnt.MeasureString(cities[i].Name).X;
                int powerOnLength = (int)fnt.MeasureString("Power: " + cities[i].IsCityActive).X;

                batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(-2 - cityNameLength / 2, -50), Color.Black);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(2 - cityNameLength / 2, -50), Color.Black);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(-cityNameLength / 2, -50 - 2), Color.Black);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(-cityNameLength / 2, -50 + 2), Color.Black);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(-cityNameLength / 2, -50), Color.White);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(-2 - powerOnLength / 2, -25), Color.Black);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(2 - powerOnLength / 2, -25), Color.Black);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(-powerOnLength / 2, -25 - 2), Color.Black);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(-powerOnLength / 2, -25 + 2), Color.Black);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position + new Vector2(cities[i].Texture.Width / 2, 0)) + new Vector2(-powerOnLength / 2, -25), Color.White);
                batch.End();
            }
        }

    }
}
