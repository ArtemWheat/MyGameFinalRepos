using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class SpawnPoint : AttackableObject
    {
        public MyTimer SpawnTimer = new MyTimer(4400);
        public SpawnPoint(string path, Vector2 pos, Vector2 dims, int ownerId) : base(path, pos, dims, ownerId)
        {
            IsDead = false;
            Health = 3;
            HealthMax = Health;
            HitDistance = 35.0f;
        }

        public override void Update(Vector2 offset)
        {
            SpawnTimer.UpdateTimer();
            if (SpawnTimer.Test())
            {
                SpawnMob();
                SpawnTimer.ResetToZero();
                if (GameGlobal.TotalScore <= 500)
                    SpawnTimer.AddToTimer(GameGlobal.TotalScore * 2);
            }
            base.Update(offset);
        }

        public virtual void SpawnMob()
        {
            GameGlobal.PassMobs(new Bug(Pos, OwnerId));
        }
    }
}
