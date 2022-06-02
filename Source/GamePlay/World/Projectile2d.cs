using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Projectile2d : Basic2d
    {
        public float Speed;
        public bool Done;
        public Vector2 Direction;
        public AttackableObject Owner;
        public MyTimer Timer;

        public Projectile2d(string oath, Vector2 pos, Vector2 dims, AttackableObject owner, Vector2 target) : base(oath, pos, dims)
        {
            Done = false;
            Speed = 5.0f;
            Owner = owner;
            Direction = target - Owner.Pos;
            Direction.Normalize();
            Rotate = Global.RotateTowards(Pos, target);
            Timer = new MyTimer(2200);
        }

        public virtual void Update(Vector2 offset, List<AttackableObject> units)
        {
            Pos += Direction * Speed;
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
                if (Owner.OwnerId != units[i].OwnerId && Global.GetDistance(Pos, units[i].Pos) < units[i].HitDistance)
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
