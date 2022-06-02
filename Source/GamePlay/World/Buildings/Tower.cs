using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Tower : Building
    {
        public Tower(Vector2 pos, int ownerId) : base("Piramid", pos, new Vector2(100,70), ownerId)
        {
            Health = 20;
            HealthMax = Health;
            HitDistance = 50.0f;
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            base.Update(offset);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
