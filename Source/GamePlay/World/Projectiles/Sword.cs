using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class Sword : Projectile2d
    {
        public Sword(Vector2 pos, Unit owner, Vector2 target) : base("Sword", pos, new Vector2(50, 50), owner, target)
        {
            Speed = 10f;
            Timer = new MyTimer(100);
        }
    }
}
