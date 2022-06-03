using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class SpiderEggSac : SpawnPoint
    {
        int MaxSpawns, TotalSpawns;
        public SpiderEggSac(Vector2 pos, int ownerId) : base("Egg", pos, new Vector2(50, 50), ownerId)
        {
            TotalSpawns = 0;
            MaxSpawns = 3;
            Health = 3;
            HealthMax = Health;
            SpawnTimer = new MyTimer(6000);
        }

        public override void SpawnMob()
        {

            var tempMob = new Spiderling(Pos, OwnerId);
            if (tempMob != null)
            {
                GameGlobal.PassMobs(tempMob);
                TotalSpawns++;
                if (TotalSpawns >= MaxSpawns)
                {
                    IsDead = true;
                }
            }
        }
    }
}
