using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Arrow : Projectile2d
    {
       
        public Arrow(Vector2 pos, AttackableObject owner, Vector2 target) : base("Core", pos, new Vector2(16, 32), owner, target)
        {
            Speed = 30.0f;
            Timer = new MyTimer(300);
        }
    }
}
