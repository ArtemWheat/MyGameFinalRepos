using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class GamePlay
    {
        int playState; //enum
        PassObject ChangeGameState;
        World world;

        public GamePlay(PassObject ChangeGameState)
        {
            this.ChangeGameState = ChangeGameState;
            playState = 0;
            ResetWorld(null);
        }

        public virtual void Update()
        {
            if (playState == 0)
            {
                world.Update();
            }
        }

        public virtual void ResetWorld(object info)
        {
            world = new World(ResetWorld, ChangeGameState);
        }

        public virtual void Draw()
        {
            if (playState == 0)
                world.Draw(Vector2.Zero);
        }

       
    }
}
