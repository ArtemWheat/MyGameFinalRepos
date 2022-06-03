using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class Pistol : Projectile2d
    {
        public Pistol(Vector2 pos, Unit owner, Vector2 target) : base("Core", pos, new Vector2(5, 10), owner, target)
        {
            Speed = 20f;
        }
    }
}
