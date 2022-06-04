using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame1
{
    public class Basic2d
    {
        protected float Rotate;
        public Vector2 Pos { get; set; }
        public Vector2 Dims { get; set; }

        public Texture2D myModel { get; set; }
        private readonly string Path;

        public Basic2d(string path, Vector2 pos, Vector2 dims)
        {
            Pos = pos;
            Dims = dims;
            Path = path;
            myModel = Global.Content.Load<Texture2D>(Path);
        }

        public virtual void Update(Vector2 offset)
        {

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
