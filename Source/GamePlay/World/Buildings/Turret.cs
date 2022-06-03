using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class Turret : Building
    {
        private int range;
        private MyTimer shotTimer;
        public Turret(Vector2 pos, int ownerId) : base("Turret", pos, new Vector2(100,100), ownerId)
        {
            range = 220;
            Health = 5;
            HealthMax = Health;
            HitDistance = 50.0f;
            shotTimer = new MyTimer(1200);
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            shotTimer.UpdateTimer();
            if (shotTimer.Test())
            {
                FireArrow(offset,enemy);
                shotTimer.ResetToZero();
            }
            base.Update(offset);

            
        }

        public virtual void FireArrow(Vector2 offset, Player enemy)
        {
            float closesDist = range;
            float currentDist = 0.0f;
            Unit closest = null;

            for (var i = 0; i < enemy.Units.Count; i++)
            {
                currentDist = Global.GetDistance(Pos, enemy.Units[i].Pos);
                if (closesDist < currentDist)
                {
                    closesDist = currentDist;
                    closest = enemy.Units[i];
                }
            }

            if (closest != null)
            {
                Rotate = Global.RotateTowards(Pos, closest.Pos - offset);
                GameGlobal.PassProjectile(new CoreTurret(Pos, this, closest.Pos));
            }
        }
    }
}
