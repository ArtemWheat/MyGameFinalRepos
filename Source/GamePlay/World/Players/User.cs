using Microsoft.Xna.Framework;

namespace MyGame1
{
    public class User : AllObjects
    {
        public User(int id) : base(id)
        {
            Hero = new Hero("HeroPix", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2), new Vector2(100, 100), Id);

            Buildings.Add(new Statue(new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2 - 50), Id));
        }
    }
}
