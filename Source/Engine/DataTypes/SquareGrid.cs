using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class SquareGrid
    {
        public bool showGrid;
        public Vector2 slotDims, gridDims, physicalStartPos, totalPhysicalDims, currentHoverSlot;
        public Basic2d gridImg;
        public List<List<GridLocation>> slots = new List<List<GridLocation>>();

        public SquareGrid(Vector2 SLOTDIMS, Vector2 STARTPOS, Vector2 TOTALDIMS)
        {
            showGrid = false;
            slotDims = SLOTDIMS;
            physicalStartPos = STARTPOS;
            totalPhysicalDims = TOTALDIMS;
            currentHoverSlot = new Vector2(-1, -1);
            SetBaseGrid();
            gridImg = new Basic2d("GridElement", slotDims / 2, new Vector2(slotDims.X - 2, slotDims.Y - 2));
        }

        public virtual void Update(Vector2 OFFSET)
        {
            currentHoverSlot = GetSlotFromPixel(Global.Mouse.newMousePos, -OFFSET);

        }

        public virtual GridLocation GetSlotFromLocation(Vector2 LOCATION)
        {
            if (LOCATION.X >= 0 && LOCATION.Y >= 0 && LOCATION.X < slots.Count && LOCATION.Y < slots[(int)LOCATION.X].Count)
                return slots[(int)LOCATION.X][(int)LOCATION.Y];
            return null;
        }

        public virtual Vector2 GetSlotFromPixel(Vector2 PIXEL, Vector2 OFFSET)
        {
            var adjustedPos = PIXEL - physicalStartPos + OFFSET;
            var tempVec = new Vector2(Math.Min(Math.Max(0, (int)(adjustedPos.X / slotDims.X)), slots.Count - 1),
                Math.Min(Math.Max(0, (int)(adjustedPos.Y / slotDims.Y)), slots[0].Count - 1));
            return tempVec;
        }

        public virtual void SetBaseGrid()
        {
            gridDims = new Vector2((int)(totalPhysicalDims.X / slotDims.X), (int)(totalPhysicalDims.Y / slotDims.Y));
            slots.Clear();
            for (var i = 0; i < gridDims.X; i++)
            {
                slots.Add(new List<GridLocation>());
                for (var j = 0; j < gridDims.Y; j++)
                {
                    slots[i].Add(new GridLocation(1, false));
                }
            }
        }

        public virtual void DrawGrid(Vector2 OFFSET)
        {
            if (showGrid)
            {
                //Vector2 topLeft = GetSlotFromPixel((new Vector2(0, 0)) / Globals.zoom  - OFFSET, Vector2.Zero);
                //Vector2 botRight = GetSlotFromPixel((new Vector2(Globals.screenWidth, Globals.screenHeight)) / Globals.zoom  - OFFSET, Vector2.Zero);
                Vector2 topLeft = GetSlotFromPixel(new Vector2(0, 0), Vector2.Zero);
                Vector2 botRight = GetSlotFromPixel(new Vector2(Global.ScreenWidth, Global.ScreenHeight), Vector2.Zero);

                Global.NormalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
                Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

                for (int j = (int)topLeft.X; j <= botRight.X && j < slots.Count; j++)
                {
                    for (int k = (int)topLeft.Y; k <= botRight.Y && k < slots[0].Count; k++)
                    {
                        if (currentHoverSlot.X == j && currentHoverSlot.Y == k)
                        {
                            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.Red.ToVector4());
                            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

                        }
                        else
                        {
                            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
                            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();
                        }

                        gridImg.Draw(OFFSET + physicalStartPos + new Vector2(j * slotDims.X, k * slotDims.Y));
                    }
                }
            }
        }
    }
}
