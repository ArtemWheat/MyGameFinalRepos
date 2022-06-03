using Microsoft.Xna.Framework;
using System;

namespace MyGame1
{
    public class Portal : SpawnPoint
    {
        private Random rnd;
        public Portal(Vector2 pos, int ownerId) : base("Hole", pos, new Vector2(200,200), ownerId)
        {
            Health = 9999;
            HealthMax = Health;
            rnd = new Random();
        }

        public override void SpawnMob()
        {
            var num = rnd.Next(0,11);
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
