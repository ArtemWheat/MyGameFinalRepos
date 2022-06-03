using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MyGame1
{
    public delegate void PassObject(object i);
    public delegate Object PassObjectAndReturn(object i);

    public static class Global
    {
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }
        public static int GameState { get; set; }
        public static ContentManager Content { get; set;  }
        public static SpriteBatch _spriteBatch { get; set; }
        public static Effect NormalEffect { get; set;  }
        public static MyKeyboard Keyboard { get; set; }
        public static MyMouseControl Mouse { get; set; }
        public static GameTime GameTime { get; set; }

        public static float GetDistance(Vector2 position, Vector2 target)
            => (float)Math.Sqrt((position.X - target.X) * (position.X - target.X) + (position.Y - target.Y) * (position.Y - target.Y));

        public static Vector2 RadialMovement(Vector2 focus, Vector2 pos, float speed) 
        {
            var dist = GetDistance(pos, focus);
            return dist <= speed ? focus - pos : (focus - pos) * speed / dist;
        }

        public static float RotateTowards(Vector2 pos, Vector2 focus)
        {

            float h, sineTheta, angle;
            if (pos.Y - focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(pos.X - focus.X, 2) + Math.Pow(pos.Y - focus.Y, 2));
                sineTheta = (float)(Math.Abs(pos.Y - focus.Y) / h);
            }
            else
            {
                h = pos.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);
            //Quadrant 2
            if (pos.X - focus.X > 0 && pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            //Quadrant 3
            else if (pos.X - focus.X > 0 && pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            //Quadrant 1
            else if (pos.X - focus.X < 0 && pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (pos.X - focus.X < 0 && pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (pos.X - focus.X > 0 && pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (pos.X - focus.X < 0 && pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (pos.X - focus.X == 0 && pos.Y - focus.Y > 0)
            {
                angle = (float)0;
            }
            else if (pos.X - focus.X == 0 && pos.Y - focus.Y < 0)
            {
                angle = (float)Math.PI;
            }
            return angle;
        }
    }
}
