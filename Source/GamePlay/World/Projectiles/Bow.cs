﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Bow : Projectile2d
    {
       
        public Bow(Vector2 pos, Unit owner, Vector2 target) : base("Core", pos, new Vector2(5, 10), owner, target)
        {
            Speed = 20f;
        }
    }
}
