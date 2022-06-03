using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MyGame1
{
    public class Projectile2d : Basic2d
    {
        public MyTimer Timer { get; set; }
        public float Speed { get; set; }
        public bool Done { get; set; }

        private readonly Vector2 direction;
        private readonly AttackableObject owner;
       

        public Projectile2d(string oath, Vector2 pos, Vector2 dims, AttackableObject owner, Vector2 target) : base(oath, pos, dims)
        {
            Done = false;
            Speed = 5.0f;
            this.owner = owner;
            direction = target - this.owner.Pos;
            direction.Normalize();
            Rotate = Global.RotateTowards(Pos, target);
            Timer = new MyTimer(2200);
        }

        public virtual void Update(Vector2 offset, List<AttackableObject> units)
        {
            Pos += direction * Speed;
            Timer.UpdateTimer();
            if (Timer.Test())
                Done = true;
            if (HitSomething(units))
                Done = true;
        }

        public virtual bool HitSomething(List<AttackableObject> units)
        {
            for (var i = 0; i < units.Count; i++)
            {
                if (owner.OwnerId != units[i].OwnerId && Global.GetDistance(Pos, units[i].Pos) < units[i].HitDistance)
                {
                    units[i].GetHit(1);
                    return true;
                }
            }
            return false;
        }

        public override void Draw(Vector2 offset)
        {
            Global.NormalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Global.NormalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Global.NormalEffect.Parameters["xDraw"].SetValue((float)(int)Dims.X);
            Global.NormalEffect.Parameters["yDraw"].SetValue((float)(int)Dims.Y);
            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw(offset);
        }
    }
}
