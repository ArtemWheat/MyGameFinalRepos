using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class StagBug : Mob
    {
        public MyTimer spawnTimer;

        public StagBug(Vector2 pos, int ownerId) : base("StagBug", pos, new Vector2(80, 120), ownerId)
        {
            Speed = 2f;
            Health = 3;
            HealthMax = Health;
            spawnTimer = new MyTimer(6000);
            spawnTimer.AddToTimer(3000);
            Name = "Spider";
        }

        public override void Update(Vector2 offset, AllObjects enemy)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnEggSac();
                spawnTimer.ResetToZero();
            }
            base.Update(offset, enemy);
        }

        public virtual void SpawnEggSac()
        {
            GameGlobal.PassSpawnPoint(new SpiderEggSac(Pos, OwnerId));
        }
    }
}
