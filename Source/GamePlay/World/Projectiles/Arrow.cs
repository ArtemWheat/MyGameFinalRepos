using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Arrow : Projectile2d
    {
       
        public Arrow(Vector2 pos, AttackableObject owner, Vector2 target) : base("Arrow", pos, new Vector2(5, 50), owner, target)
        {
            Speed = 30.0f;
            Timer = new MyTimer(300);
        }

        public override void Update(Vector2 offset, List<AttackableObject> units)
        {
            base.Update(offset, units);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
