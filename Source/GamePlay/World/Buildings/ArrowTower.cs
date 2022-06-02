using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class ArrowTower : Building
    {
        int Range;
        MyTimer ShotTimer = new MyTimer(1200);
        public ArrowTower(Vector2 pos, int ownerId) : base("Tower", pos, new Vector2(50,50), ownerId)
        {
            Range = 220;
            Health = 5;
            HealthMax = Health;
            HitDistance = 50.0f;
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            ShotTimer.UpdateTimer();
            if (ShotTimer.Test())
            {
                FireArrow(enemy);
                ShotTimer.ResetToZero();
            }
            base.Update(offset);
        }

        public virtual void FireArrow(Player enemy)
        {
            float closesDist = Range;
            float currentDist = 0.0f;
            Unit closest = null;

            for (var i = 0; i < enemy.units.Count; i++)
            {
                currentDist = Global.GetDistance(Pos, enemy.units[i].Pos);
                if (closesDist < currentDist)
                {
                    closesDist = currentDist;
                    closest = enemy.units[i];
                }
            }

            if (closest != null)
            {
                GameGlobal.PassProjectile(new Arrow(Pos, this, closest.Pos));
            }
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
