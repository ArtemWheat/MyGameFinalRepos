using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class CoreTurret : Projectile2d
    {
        public CoreTurret(Vector2 pos, AttackableObject owner, Vector2 target) : base("Core", pos, new Vector2(16, 32), owner, target)
        {
            Speed = 30.0f;
            Timer = new MyTimer(300);
        }
    }
}
