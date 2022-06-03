using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Tower : Building
    {
        public Tower(Vector2 pos, int ownerId) : base("Statue", pos, new Vector2(100,100), ownerId)
        {
            Health = 20;
            HealthMax = Health;
            HitDistance = 50.0f;
        }
    }
}
