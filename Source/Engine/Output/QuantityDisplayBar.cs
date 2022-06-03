using Microsoft.Xna.Framework;


namespace MyGame1
{
    public class QuantityDisplayBar
    {
        private int boarder;
        private Basic2d bar;
        private Basic2d barBKG;
        private Color color;
        public QuantityDisplayBar(Vector2 dims, int boarder, Color color)
        {
            this.boarder = boarder;
            this.color = color;
            bar = new Basic2d("solid", new Vector2(0, 0), new Vector2(dims.X - this.boarder * 2, dims.Y - this.boarder * 2));
            barBKG = new Basic2d("shade", new Vector2(0, 0), new Vector2(dims.X - this.boarder * 2, dims.Y - this.boarder * 2));
        }

        public virtual void Update(float current, float max)
        {
            bar.Dims = new Vector2(current/max * (barBKG.Dims.X - boarder * 2), bar.Dims.Y);
        }

        public virtual void Draw(Vector2 offset)
        {
            Global.NormalEffect.Parameters["xSize"].SetValue(1.0f);
            Global.NormalEffect.Parameters["ySize"].SetValue(1.0f);
            Global.NormalEffect.Parameters["xDraw"].SetValue(1.0f);
            Global.NormalEffect.Parameters["yDraw"].SetValue(1.0f);
            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.Black.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

            barBKG.Draw(offset, Vector2.Zero, Color.Black);

            Global.NormalEffect.Parameters["filterColor"].SetValue(color.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

            bar.Draw(offset + new Vector2(boarder, boarder), Vector2.Zero, color);
        }
    }
}
