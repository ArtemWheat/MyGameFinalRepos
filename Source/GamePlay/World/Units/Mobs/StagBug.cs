using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class StagBug : Mob
    {
        private MyTimer spawnTimer;

        public StagBug(Vector2 pos, int ownerId) : base("StagBug", pos, new Vector2(80, 120), ownerId)
        {
            Speed = 2f;
            Health = 3;
            HealthMax = Health;
            spawnTimer = new MyTimer(6000);
            spawnTimer.AddToTimer(3000);
            Name = "Spider";
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnEggSac();
                spawnTimer.ResetToZero();
            }
            base.Update(offset, enemy);
        }

        public void SpawnEggSac()
        {
            GameGlobal.PassSpawnPoint(new SpiderEggSac(Pos, OwnerId));
        }
    }
}
