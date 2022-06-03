﻿using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class Portal : SpawnPoint
    {
        public Portal(Vector2 pos, int ownerId) : base("Hole", pos, new Vector2(200,200), ownerId)
        {
            Health = 9999;
            HealthMax = Health;
        }

        public override void SpawnMob()
        {
            var num = Global.Rnd.Next(0,11);
            Mob tempMob = null;
            if (num < 5)
            {
                tempMob = new Bug(Pos, OwnerId);
            }
            else if (num < 8)
            {
                tempMob = new StagBug(Pos, OwnerId);
            }
            if(tempMob != null)
                GameGlobal.PassMobs(tempMob);
        }
    }
}
