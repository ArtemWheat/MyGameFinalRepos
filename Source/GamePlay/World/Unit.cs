using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Unit : AttackableObject
    {
        public string Name;
        public Unit(string path, Vector2 pos, Vector2 dims, int ownerId) : base(path, pos, dims, ownerId)
        {
            
        }
    }
}
