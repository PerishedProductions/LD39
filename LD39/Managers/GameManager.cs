using LD39.Entity;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
