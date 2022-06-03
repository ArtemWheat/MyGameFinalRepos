using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Imp : Mob
    {

        public Imp(Vector2 POS, int OWNERID) : base("Bug", POS, new Vector2(100, 100), OWNERID)
        {
            Speed = 2f;
            Name = "Imp";
        }

        /*public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            
            base.Update(OFFSET, ENEMY);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }*/
    }
}
