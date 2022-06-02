using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Portal : SpawnPoint
    {
        public Portal(Vector2 pos, int ownerId) : base("Portal", pos, new Vector2(50,50), ownerId)
        {
            Health = 9999;
            HealthMax = Health;
        }

        public override void Update(Vector2 offset)
        {
            base.Update(offset);
        }

        public override void SpawnMob()
        {
            var num = Global.Rnd.Next(0,11);
            Mob tempMob = null;
            if (num < 5)
            {
                tempMob = new Imp(Pos, OwnerId);
            }
            else if (num < 8)
            {
                tempMob = new Spider(Pos, OwnerId);
            }
            if(tempMob != null)
                GameGlobal.PassMobs(tempMob);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
