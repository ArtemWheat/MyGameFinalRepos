using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class MachineGun : Projectile2d
    {
        public MachineGun(Vector2 pos, Unit owner, Vector2 target) : base("CoreRed", pos, new Vector2(7, 15), owner, target)
        {
            Speed = 20f;
        }
    }
}
