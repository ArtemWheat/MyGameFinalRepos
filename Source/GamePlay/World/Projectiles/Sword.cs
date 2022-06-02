using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Sword : Projectile2d
    {
       
        public Sword(Vector2 pos, Unit owner, Vector2 target) : base("Sword", pos, new Vector2(10, 40), owner, target)
        {
            Speed = 20f;
            Timer = new MyTimer(70);
        }

        public override void Update(Vector2 offset, List<AttackableObject> units)
        {
            base.Update(offset, units);
        }

        public override void Draw(Vector2 pffset)
        {
            base.Draw(pffset);
        }
    }
}
