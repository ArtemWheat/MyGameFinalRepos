using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class GridLocation
    {
        public bool filled, imprassible, unPathable;
        public float fScore, cost, currentDist;
        public Vector2 parent, pos;
        public GridLocation(float COST, bool FILLED)
        {
            cost = COST;
            filled = FILLED;
            unPathable = false;
            imprassible = false;
        }

        public virtual void SetToFilled(bool IMPRESSIBLE)
        {
            filled = true;
            imprassible = IMPRESSIBLE;
        }
    }
}
