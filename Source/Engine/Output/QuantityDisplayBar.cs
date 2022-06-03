using Microsoft.Xna.Framework;


namespace MyGame1
{
    public class QuantityDisplayBar
    {
        public int Boarder;
        public Basic2d Bar, BarBKG;
        public Color Color;
        public QuantityDisplayBar(Vector2 dims, int boarder, Color color)
        {
            Boarder = boarder;
            Color = color;
            Bar = new Basic2d("solid", new Vector2(0, 0), new Vector2(dims.X - Boarder * 2, dims.Y - Boarder * 2));
            BarBKG = new Basic2d("shade", new Vector2(0, 0), new Vector2(dims.X - Boarder * 2, dims.Y - Boarder * 2));
        }

        public virtual void Update(float current, float max)
        {
            Bar.Dims = new Vector2(current/max * (BarBKG.Dims.X - Boarder * 2), Bar.Dims.Y);
        }

        public virtual void Draw(Vector2 offset)
        {
            Global.NormalEffect.Parameters["xSize"].SetValue(1.0f);
            Global.NormalEffect.Parameters["ySize"].SetValue(1.0f);
            Global.NormalEffect.Parameters["xDraw"].SetValue(1.0f);
            Global.NormalEffect.Parameters["yDraw"].SetValue(1.0f);
            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.Black.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

            BarBKG.Draw(offset, Vector2.Zero, Color.Black);

            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

            Bar.Draw(offset + new Vector2(Boarder, Boarder), Vector2.Zero, Color);
        }
    }
}
