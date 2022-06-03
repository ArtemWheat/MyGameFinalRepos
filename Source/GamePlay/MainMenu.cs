/*using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class MainMenu
    {
        private Basic2d mainMenuStart;
        private Basic2d mainMenuExit;
        private Dictionary<int, bool> menuState;
        PassObject ChangeGameState;
        PassObject ChangeExit;

        public MainMenu(PassObject ChangeGameState, PassObject ChangeExit)
        {
            mainMenuStart = new Basic2d("MainMenuStart", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2), new Vector2(Global.ScreenWidth, Global.ScreenHeight));
            mainMenuExit = new Basic2d("MainMenuExit", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2), new Vector2(Global.ScreenWidth, Global.ScreenHeight));
            this.ChangeGameState = ChangeGameState;
            this.ChangeExit = ChangeExit;
            menuState = new Dictionary<int, bool>()
            {
                [0] = true,
                [1] = false
            };
        }

        public virtual void Update()
        {
            if (Global.GameState == 0 && Global.Keyboard.GetSinglePress("S"))
            {
                menuState[0] = false;
                menuState[1] = true;
            }

            if (Global.GameState == 0 && Global.Keyboard.GetSinglePress("W"))
            {
                menuState[0] = true;
                menuState[1] = false;
            }

        }

        public virtual void Draw()
        {
            if (menuState[0])
                mainMenuStart.Draw(Vector2.Zero);
            if (menuState[1])
                mainMenuExit.Draw(Vector2.Zero);
        }
    }
}
*/