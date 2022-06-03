using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{

    public class Hero : Unit
    {
        public int CostArrowTower;
        public readonly int CostBow;
        public readonly int CostCrossBow;
        private int ProjectilesType;
        public Dictionary<int, bool> OwnerProjectiles;
        private MyTimer timerCrossbow;
        public Hero(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS, OWNERID)
        {
            CostArrowTower = 50;
            CostBow = 20;
            CostCrossBow = 50;
            ProjectilesType = 0;
            Rotate = 3.1f;
            Speed = 3.0f;
            Health = 20;
            HealthMax = Health;

            timerCrossbow = new MyTimer(150);

            OwnerProjectiles = new Dictionary<int, bool>()
            {
                [0] = true,
                [1] = false,
                [2] = false
            };
        } 

        public override void Update(Vector2 offset)
        {
            bool checkScroll = false;

            if (Global.Keyboard.GetPress("A") && Pos.X >= -100)
            {
                Pos = new Vector2(Pos.X - Speed, Pos.Y);
                checkScroll = true;
            }

            if (Global.Keyboard.GetPress("D") && Pos.X <= 1600)
            {
                Pos = new Vector2(Pos.X + Speed, Pos.Y);
                checkScroll = true;
            }

            if (Global.Keyboard.GetPress("W") && Pos.Y >= -100)
            {
                Pos = new Vector2(Pos.X, Pos.Y - Speed);
                checkScroll = true;
            }

            if (Global.Keyboard.GetPress("S") && Pos.Y <= 900)
            {
                Pos = new Vector2(Pos.X, Pos.Y + Speed);
                checkScroll = true;
            }

            if ((Global.Keyboard.GetSinglePress("Q") || Global.Mouse.RightClick()) && GameGlobal.Score >= CostArrowTower)
            {
                GameGlobal.PassBuilding(new ArrowTower(new Vector2(Pos.X + 30, Pos.Y - 30), OwnerId));
                GameGlobal.Score -= CostArrowTower;
                CostArrowTower += 10; // выводить на экран
            }

            if (Global.Keyboard.GetSinglePress("D2") || Global.Keyboard.GetPress("D2"))
            {
                if (GameGlobal.Score >= CostBow && !OwnerProjectiles[1])
                {
                    ProjectilesType = 1;
                    GameGlobal.Score -= CostBow;
                    OwnerProjectiles[1] = true;
                }
                //ProjectilesType = 1;
            }



            if (Global.Keyboard.GetSinglePress("D1"))
                ProjectilesType = 0;

            if (Global.Keyboard.GetSinglePress("D3"))
            {
                if (GameGlobal.Score >= CostCrossBow && !OwnerProjectiles[2])
                {
                    ProjectilesType = 2;
                    GameGlobal.Score -= CostCrossBow;
                    OwnerProjectiles[2] = true;
                }
            }

            if (checkScroll)
            {
                GameGlobal.CheckScroll(Pos);
            }

            Rotate = Global.RotateTowards(Pos, Global.Mouse.newMousePos - offset);

            if (Global.Mouse.LeftClick())
            {
                switch (ProjectilesType)
                {
                    case 0:
                        GameGlobal.PassProjectile(new Sword(Pos, this, Global.Mouse.newMousePos - offset));
                        break;
                    case 1:
                        GameGlobal.PassProjectile(new Bow(Pos, this, Global.Mouse.newMousePos - offset));
                        break;
                }
            }

            if (Global.Mouse.LeftClickHold())
            {
                if (ProjectilesType == 2)
                {
                    timerCrossbow.UpdateTimer();
                    if (timerCrossbow.Test())
                    {
                        GameGlobal.PassProjectile(new Crossbow(Pos, this, Global.Mouse.newMousePos - offset));
                        timerCrossbow.ResetToZero();
                    }
                }
            }


            base.Update(offset);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
