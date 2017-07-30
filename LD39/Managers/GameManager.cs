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
                batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position) + new Vector2(5 - 2, -50), Color.Black);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position) + new Vector2(5 + 2, -50), Color.Black);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position) + new Vector2(5, -50 - 2), Color.Black);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position) + new Vector2(5, -50 + 2), Color.Black);
                batch.DrawString(fnt, cities[i].Name, cam.ToScreen(cities[i].Position) + new Vector2(5, -50), Color.White);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position) + new Vector2(-15 - 2, -25), Color.Black);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position) + new Vector2(-15 + 2, -25), Color.Black);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position) + new Vector2(-15, -25 - 2), Color.Black);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position) + new Vector2(-15, -25 + 2), Color.Black);
                batch.DrawString(fnt, "Power: " + cities[i].IsCityActive, cam.ToScreen(cities[i].Position) + new Vector2(-15, -25), Color.White);
                batch.End();
            }
        }

    }
}
