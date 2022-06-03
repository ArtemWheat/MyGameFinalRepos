using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class Spiderling : Mob
    {
        public Spiderling(Vector2 pos, int ownerId) : base("Spiderling", pos, new Vector2(40,40), ownerId)
        {
            Speed = 2f;
            Name = "Spiderling";
        }

        public override void AI(AllObjects enemy)
        {
            Building temp = null;
            for (var i = 0; i < enemy.Buildings.Count; i++)
            {
                if (enemy.Buildings[i].GetType().ToString() == "MyGame1.Statue")
                {
                    temp = enemy.Buildings[i];
                }
            }
            if (temp != null)
            {
                Pos += Global.RadialMovement(temp.Pos, Pos, Speed + 5);
                Rotate = Global.RotateTowards(Pos, temp.Pos);
                if (Global.GetDistance(Pos, temp.Pos) < 15)
                {
                    temp.GetHit(1);
                    IsDead = true;
                }
            }
        }
    }
}