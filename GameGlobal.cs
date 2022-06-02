using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class GameGlobal
    {
        public static int Score;
        public static int TotalScore;
        public static bool Paused = false;
        public static PassObject PassProjectile, PassMobs, PassBuilding, CheckScroll, PassSpawnPoint;
    }
}
