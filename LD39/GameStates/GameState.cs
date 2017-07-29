using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD39.GameStates
{
    public class GameState
    {

        GameState(Game1 game)
        {
            this.game = game;
        }

        public Game1 game;

        public virtual void Init()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }

    }
}
