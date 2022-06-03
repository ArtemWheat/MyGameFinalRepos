using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class GamePlay
    {
        PassObject ChangeGameState;
        World world;

        public GamePlay(PassObject ChangeGameState)
        {
            this.ChangeGameState = ChangeGameState;
            ResetWorld(null);
        }

        public virtual void Update()
        {
            
            world.Update();

            if (Global.GameState == 1 && Global.Keyboard.GetSinglePress("Backspace"))
            {
                ChangeGameState(0);
            }
                
        }

        public virtual void ResetWorld(object info)
        {
            world = new World(ResetWorld, ChangeGameState);
        }

        public virtual void Draw()
        {
            world.Draw(Vector2.Zero);
        }

       
    }
}
