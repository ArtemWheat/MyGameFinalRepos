using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Basic2d
    {
        public float Rotate;
        public Vector2 Pos, Dims;

        public Texture2D myModel;
        public Basic2d(string path, Vector2 pos, Vector2 dims)
        {
            Pos = pos;
            Dims = dims;
            myModel = Global.Content.Load<Texture2D>(path);
        }

        public virtual void Update(Vector2 offset)
        {

        }

        public virtual bool Hover(Vector2 offset)
        {
            return HoverImg(offset);
        }

        public virtual bool HoverImg(Vector2 offset)
        {
            var mousePos = Global.Mouse.newMousePos;
            if (mousePos.X >= (Pos.X + offset.X) - Dims.X / 2 && mousePos.X >= (Pos.X + offset.X) + Dims.X / 2
                && mousePos.Y >= (Pos.Y + offset.Y) - Dims.Y / 2 && mousePos.Y >= (Pos.Y + offset.Y) + Dims.Y / 2)
                return true;
            return false;
        }

        public virtual void Draw(Vector2 offset)
        {
            if (myModel != null)
                Global._spriteBatch.Draw(myModel,
                    new Rectangle((int)(Pos.X + offset.X), (int)(Pos.Y + offset.Y), (int)Dims.X, (int)Dims.Y),
                    null,
                    Color.White,
                    Rotate,
                    new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2),
                    new SpriteEffects(),
                    0);
        }

        public virtual void Draw(Vector2 offset, Vector2 origin, Color color)
        {
            if (myModel != null)
                Global._spriteBatch.Draw(myModel,
                    new Rectangle((Pos + offset).ToPoint(), Dims.ToPoint()),
                    null,
                    color,
                    Rotate,
                    origin,
                    new SpriteEffects(),
                    0);
        }
    }
}
