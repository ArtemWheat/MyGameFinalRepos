using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class User : Player
    {
        public User(int id) : base(id)
        {
            Hero = new Hero("SuperHero", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2), new Vector2(100, 100), Id);
            Buildings.Add(new Tower(new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2 - 50), Id));
        }

        public virtual void Update(User enemy, Vector2 offset)
        {
            base.Update(enemy, offset);
        }    
    }
}
