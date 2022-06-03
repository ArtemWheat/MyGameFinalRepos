using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class Mob : Unit
    {
        private MyTimer timerHit;
        
        public Mob(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS, OWNERID)
        {
            Speed = 0.1f;
            timerHit = new MyTimer(100);
        }

        public override void Update(Vector2 OFFSET, AllObjects ENEMY)
        {
            AI(ENEMY);
            base.Update(OFFSET);
        }

        public virtual void AI(AllObjects ENEMY)
        {
            Pos += Global.RadialMovement(ENEMY.Hero.Pos, Pos, Speed );
            Rotate = Global.RotateTowards(Pos, ENEMY.Hero.Pos);
            if (Global.GetDistance(Pos, ENEMY.Hero.Pos) < 15)
            {
                timerHit.UpdateTimer();
                if (timerHit.Test())
                {
                    ENEMY.Hero.GetHit(1);
                    timerHit = new MyTimer(2000);
                }
            }
        }
    }
}
