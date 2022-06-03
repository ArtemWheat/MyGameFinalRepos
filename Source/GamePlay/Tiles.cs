using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Tiles
    {
        private TilesBkg2D bkg;
        private TilesBkg2D bkgBorderUp;
        private TilesBkg2D bkgBorderDown;
        private TilesBkg2D bkgBorderRight;
        private TilesBkg2D bkgBorderLeft;
        private TilesBkg2D bkgCorner0;
        private TilesBkg2D bkgCorner1;
        private TilesBkg2D bkgCorner2;
        private TilesBkg2D bkgCorner3;
        private Basic2d hummock;


        public Tiles()
        {
            bkg = new TilesBkg2D("GameBKG", new Vector2(-100, -100), new Vector2(16), new Vector2(1700, 1000));
            bkgBorderUp = new TilesBkg2D("WallUp100", new Vector2(-100, -150), new Vector2(50), new Vector2(1700, 50));
            bkgBorderDown = new TilesBkg2D("WallDown100", new Vector2(-100, 900), new Vector2(50), new Vector2(1700, 50));
            bkgBorderRight = new TilesBkg2D("WallRight100", new Vector2(1600, -100), new Vector2(50), new Vector2(50, 1000));
            bkgBorderLeft = new TilesBkg2D("WallLeft100", new Vector2(-150, -100), new Vector2(50), new Vector2(50, 1000));
            bkgCorner0 = new TilesBkg2D("Corner0", new Vector2(-150), new Vector2(50), new Vector2(50));
            bkgCorner1 = new TilesBkg2D("Corner1", new Vector2(1600,-150), new Vector2(50), new Vector2(50));
            bkgCorner2 = new TilesBkg2D("Corner2", new Vector2(1600, 900), new Vector2(50), new Vector2(50));
            bkgCorner3 = new TilesBkg2D("Corner3", new Vector2(-150, 900), new Vector2(50), new Vector2(50));
            hummock = new Basic2d("Hummock", new Vector2(1200, 600), new Vector2(100));
        }

        public void Draw(Vector2 Offset)
        {
            bkgBorderUp.Draw(Offset);
            bkgBorderRight.Draw(Offset);
            bkgBorderDown.Draw(Offset);
            bkgBorderLeft.Draw(Offset);
            bkg.Draw(Offset);
            bkgCorner0.Draw(Offset);
            bkgCorner1.Draw(Offset);
            bkgCorner2.Draw(Offset);
            bkgCorner3.Draw(Offset);
            hummock.Draw(Offset);
        }
    }
}
