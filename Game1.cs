using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MyGame1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GamePlay gamePlay;
        //MainMenu mainMenu;
        Basic2d cursor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.IsMouseVisible = false;
            Global.ScreenHeight = 900;
            Global.ScreenWidth = 1600;
            //mainMenu = new MainMenu(ChangeGameState, ExitGame);

            _graphics.PreferredBackBufferWidth = Global.ScreenWidth;
            _graphics.PreferredBackBufferHeight = Global.ScreenHeight;

            _graphics.ApplyChanges();

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
            //mainMenu = new MainMenu(ChangeGameState, ExitGame);
            gamePlay = new GamePlay(ChangeGameState);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Global.GameTime = gameTime;
            Global.Keyboard.Update();
            Global.Mouse.Update();
            gamePlay.Update();
            /*if (Global.gameState == 0)
                mainMenu.Update();
            else if(Global.gameState == 1)
                gamePlay.Update();*/

            Global.Keyboard.UpdateOld();
            Global.Mouse.UpdateOld();

            base.Update(gameTime);
        }

        public virtual void ChangeGameState(object info)
        {
            Global.GameState = Convert.ToInt32(info);
        }

        public virtual void ExitGame(object INFO)
        {
            Exit();
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Global._spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            /* if (Global.gameState == 0)
                 mainMenu.Draw();
             else if (Global.gameState == 1)
                 gamePlay.Draw();*/

            gamePlay.Draw();
            cursor.Draw(Global.Mouse.newMousePos, Vector2.Zero, Color.White);

            Global._spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
