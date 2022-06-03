using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Text;

namespace MyGame1
{
    public class DeadTrace : Basic2d
    {
        public DeadTrace(string path, Vector2 pos, Vector2 dims) : base(path, pos, dims)
        {

        }

        public override void Draw(Vector2 offset)
        {
            Global.NormalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Global.NormalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Global.NormalEffect.Parameters["xDraw"].SetValue((float)((int)Dims.X));
            Global.NormalEffect.Parameters["yDraw"].SetValue((float)((int)Dims.Y));
            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw(offset);
        }
    }
}
