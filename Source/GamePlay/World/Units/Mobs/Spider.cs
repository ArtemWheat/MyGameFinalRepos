using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Spider : Mob
    {
        public MyTimer spawnTimer;

        public Spider(Vector2 pos, int ownerId) : base("Spider", pos, new Vector2(45, 45), ownerId)
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

        public virtual void SpawnEggSac()
        {
            GameGlobal.PassSpawnPoint(new SpiderEggSac(Pos, OwnerId));
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
