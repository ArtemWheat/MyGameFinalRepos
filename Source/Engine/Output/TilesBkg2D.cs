using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MyGame1
{
    public class TilesBkg2D : Basic2d
    {
        public Vector2 BkgDims;
        public TilesBkg2D(string path, Vector2 pos, Vector2 dims, Vector2 bkgdims) : base(path, pos, new Vector2((float)Math.Floor(dims.X), (float)Math.Floor(dims.Y)))
        {
            BkgDims = new Vector2((float)Math.Floor(bkgdims.X), (float)Math.Floor(bkgdims.Y));
        }

        public override void Draw(Vector2 offset)
        {
            var numX = (float)Math.Ceiling(BkgDims.X / Dims.X);
            var numY = (float)Math.Ceiling(BkgDims.Y / Dims.Y);
            for (var i = 0; i < numX; i++)
            {
                for (var j = 0; j < numY; j++)
                {
                    if(i < numX - 1 && j < numY - 1)
                        base.Draw(offset + new Vector2(Dims.X/2 + Dims.X * i, Dims.Y / 2 + Dims.Y * j));
                    else
                    {
                        var xLeft = (float)Math.Min(Dims.X, BkgDims.X - i * Dims.X);
                        var yLeft = (float)Math.Min(Dims.Y, BkgDims.Y - j * Dims.Y);
                        var xPrecentLeft = (float)Math.Min(1, xLeft/Dims.X);
                        var yPrecentLeft = (float)Math.Min(1, yLeft / Dims.Y);


                        Global._spriteBatch.Draw(myModel, 
                            new Rectangle((int)(Pos.X + offset.X + Dims.X * i), (int)(Pos.Y + offset.Y + Dims.Y * j), 
                            (int)Math.Ceiling(Dims.X * xPrecentLeft), (int)Math.Ceiling(Dims.Y * yPrecentLeft)), 

                            new Rectangle(0,0,(int)(xPrecentLeft * myModel.Bounds.Width), (int)(yPrecentLeft * myModel.Bounds.Height)), 
                            Color.White,
                            Rotate,
                            Vector2.Zero,
                            new SpriteEffects(),
                            0);
                    }
                }
            }
        }
    }
}
