using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class AttackableObject : Basic2d
    {
        public bool IsDead;
        public int OwnerId;
        public float Speed, HitDistance, Health, HealthMax;
        public AttackableObject(string path, Vector2 pos, Vector2 dims, int ownerId) : base(path, pos, dims)
        {
            OwnerId = ownerId;
            //speed = 5.0f;
            IsDead = false;
            Health = 1;
            HealthMax = Health;
            HitDistance = 35.0f;
        }

        public virtual void Update(Vector2 offset, AllObjects enemy)
        {
            base.Update(offset);
        }

        public virtual void GetHit(float damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                IsDead = true;
            }
                
        }

        public override void Draw(Vector2 offset)
        {
            Global.NormalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Global.NormalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Global.NormalEffect.Parameters["xDraw"].SetValue((float)(int)Dims.X);
            Global.NormalEffect.Parameters["yDraw"].SetValue((float)(int)Dims.Y);
            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw(offset);
        }
    }
}
