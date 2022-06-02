using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public delegate void PassObject(object i);
    public delegate Object PassObjectAndReturn(object i);

    public class Global
    {
        public static int ScreenWidth, ScreenHeight, GameState = 0;

        public static Random Rnd = new Random();

        public static ContentManager Content;
        public static SpriteBatch _spriteBatch;
        public static Effect NormalEffect;
        public static MyKeyboard Keyboard;
        public static MyMouseControl Mouse;
        public static GameTime GameTime;

        public static float GetDistance(Vector2 position, Vector2 target)
            => (float)Math.Sqrt((position.X - target.X) * (position.X - target.X) + (position.Y - target.Y) * (position.Y - target.Y));

        public static Vector2 RadialMovement(Vector2 focus, Vector2 pos, float speed) //тернанрный
        {
            float dist = GetDistance(pos, focus);

            if (dist <= speed)
            {
                return focus - pos;
            }
            else
            {
                return (focus - pos) * speed / dist;
            }
        }

        public static float RotateTowards(Vector2 pos, Vector2 focus)
        {

            float h, sineTheta, angle;
            if (pos.Y - focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(pos.X - focus.X, 2) + Math.Pow(pos.Y - focus.Y, 2));
                sineTheta = (float)(Math.Abs(pos.Y - focus.Y) / h); //* ((item.Pos.Y-focus.Y)/(Math.Abs(item.Pos.Y-focus.Y))));
            }
            else
            {
                h = pos.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            //Drawing diagonial lines here.
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
