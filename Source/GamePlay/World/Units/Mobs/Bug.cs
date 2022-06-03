using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class Bug : Mob
    {
        public Bug(Vector2 POS, int OWNERID) : base("Bug", POS, new Vector2(100, 100), OWNERID)
        {
            Speed = 2f;
            Name = "Imp";
        }
    }
}
