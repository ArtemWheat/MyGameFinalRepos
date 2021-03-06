using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class GamePlay
    {
        private readonly PassObject ChangeGameState;
        private World world;

        public GamePlay(PassObject ChangeGameState)
        {
            this.ChangeGameState = ChangeGameState;
            ResetWorld(null);
        }

        public void Update()
        {
            
            world.Update();

            if (Global.GameState == 1 && Global.Keyboard.GetSinglePress("Backspace"))
            {
                ChangeGameState(0);
            }
                
        }

        public void ResetWorld(object info)
        {
            world = new World(ResetWorld, ChangeGameState);
        }

        public void Draw()
        {
            world.Draw(Vector2.Zero);
        }
    }
}
