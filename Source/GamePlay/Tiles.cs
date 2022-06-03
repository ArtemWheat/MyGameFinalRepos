using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Tiles
    {
        public TilesBkg2D Bkg;
        public TilesBkg2D BkgBorderUp;
        public TilesBkg2D BkgBorderDown;
        public TilesBkg2D BkgBorderRight;
        public TilesBkg2D BkgBorderLeft;
        public TilesBkg2D BkgCorner0;
        public TilesBkg2D BkgCorner1;
        public TilesBkg2D BkgCorner2;
        public TilesBkg2D BkgCorner3;
        //public TilesBkg2D DistantBkg;

        public Tiles()
        {
            Bkg = new TilesBkg2D("GameBKG", new Vector2(-100, -100), new Vector2(16), new Vector2(1700, 1000));
            BkgBorderUp = new TilesBkg2D("WallUp100", new Vector2(-100, -150), new Vector2(50), new Vector2(1700, 50));
            BkgBorderDown = new TilesBkg2D("WallDown100", new Vector2(-100, 900), new Vector2(50), new Vector2(1700, 50));
            BkgBorderRight = new TilesBkg2D("WallRight100", new Vector2(1600, -100), new Vector2(50), new Vector2(50, 1000));
            BkgBorderLeft = new TilesBkg2D("WallLeft100", new Vector2(-150, -100), new Vector2(50), new Vector2(50, 1000));
            BkgCorner0 = new TilesBkg2D("Corner0", new Vector2(-150), new Vector2(50), new Vector2(50));
            BkgCorner1 = new TilesBkg2D("Corner1", new Vector2(1600,-150), new Vector2(50), new Vector2(50));
            BkgCorner2 = new TilesBkg2D("Corner2", new Vector2(1600, 900), new Vector2(50), new Vector2(50));
            BkgCorner3 = new TilesBkg2D("Corner3", new Vector2(-150, 900), new Vector2(50), new Vector2(50));
            //DistantBkg = new TilesBkg2D("DistantBKG", new Vector2(-1000), new Vector2(50), new Vector2(1000,1000));
        }

        public virtual void Draw(Vector2 Offset)
        {
            //DistantBkg.Draw(Offset);
            BkgBorderUp.Draw(Offset);
            BkgBorderRight.Draw(Offset);
            BkgBorderDown.Draw(Offset);
            BkgBorderLeft.Draw(Offset);
            Bkg.Draw(Offset);
            BkgCorner0.Draw(Offset);
            BkgCorner1.Draw(Offset);
            BkgCorner2.Draw(Offset);
            BkgCorner3.Draw(Offset);
        }
    }
}
