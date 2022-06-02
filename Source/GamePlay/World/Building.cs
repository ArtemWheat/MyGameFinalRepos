using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Building : AttackableObject
    {
        public Building(string path, Vector2 pos, Vector2 dims, int ownerId) : base(path, pos, dims, ownerId)
        {
            
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            base.Update(offset);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
