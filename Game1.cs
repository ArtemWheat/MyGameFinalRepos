using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MyGame1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private GamePlay gamePlay;
        private Basic2d mainMenuStart;
        private Basic2d mainMenuExit;
        private Basic2d cursor;
        private Dictionary<int, bool> menuState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = false;
            Global.ScreenHeight = 900;
            Global.ScreenWidth = 1600;

            _graphics.PreferredBackBufferWidth = Global.ScreenWidth;
            _graphics.PreferredBackBufferHeight = Global.ScreenHeight;

            _graphics.ApplyChanges();
            menuState = new Dictionary<int, bool>()
            {
                [0] = true,
                [1] = false
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Global.Content = this.Content;
            Global._spriteBatch = new SpriteBatch(GraphicsDevice);

            cursor = new Basic2d("Cursor", Vector2.Zero, new Vector2(28, 28));
            Global.NormalEffect = Global.Content.Load<Effect>("NormalFlat");
            Global.Keyboard = new MyKeyboard();
            Global.Mouse = new MyMouseControl();
            mainMenuStart = new Basic2d("MainMenuStart",new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2), new Vector2(Global.ScreenWidth,Global.ScreenHeight));
            mainMenuExit = new Basic2d("MainMenuExit", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2), new Vector2(Global.ScreenWidth, Global.ScreenHeight));
            gamePlay = new GamePlay(ChangeGameState);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Global.GameTime = gameTime;
            Global.Keyboard.Update();
            Global.Mouse.Update();


            if (Global.GameState == 0 && Global.Keyboard.GetSinglePress("Space") && menuState[0])
                ChangeGameState(1);

            if (Global.GameState == 0 && Global.Keyboard.GetSinglePress("Space") && menuState[1])
                ExitGame(null);

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


            if (Global.GameState == 1)
                gamePlay.Update();

            Global.Keyboard.UpdateOld();
            Global.Mouse.UpdateOld();

            base.Update(gameTime);
        }

        public void ChangeGameState(object newState)
        {
            Global.GameState = Convert.ToInt32(newState);
        }

        public void ExitGame(object INFO)
        {
            Exit();
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(78,83,61));

            Global._spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            if (Global.GameState == 0)
            {
                if (menuState[0])
                    mainMenuStart.Draw(Vector2.Zero);
                if (menuState[1])
                    mainMenuExit.Draw(Vector2.Zero);
            }
            else if (Global.GameState == 1)
                gamePlay.Draw();

            if(Global.GameState == 1)
                cursor.Draw(Global.Mouse.newMousePos, Vector2.Zero, Color.White);

            Global._spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
