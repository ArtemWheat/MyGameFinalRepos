﻿using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class Turret : Building
    {
        int Range;
        MyTimer ShotTimer = new MyTimer(1200);
        public Turret(Vector2 pos, int ownerId) : base("Turret", pos, new Vector2(100,100), ownerId)
        {
            Range = 220;
            Health = 5;
            HealthMax = Health;
            HitDistance = 50.0f;
        }

        public override void Update(Vector2 offset, AllObjects enemy)
        {
            ShotTimer.UpdateTimer();
            if (ShotTimer.Test())
            {
                FireArrow(offset,enemy);
                ShotTimer.ResetToZero();
            }
            base.Update(offset);

            
        }

        public virtual void FireArrow(Vector2 offset, AllObjects enemy)
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
                Rotate = Global.RotateTowards(Pos, closest.Pos - offset);
                GameGlobal.PassProjectile(new CoreTurret(Pos, this, closest.Pos));
            }
        }
    }
}