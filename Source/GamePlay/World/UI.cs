using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame1
{
    public class UI
    {
        public SpriteFont Font;
        public Basic2d PauseOverlay;
        public QuantityDisplayBar HealthBar;
        public QuantityDisplayBar HealthTowerBar;
        public Basic2d WeaponBar;
        //public Button2d ResetBtn;

        public UI(PassObject RESET)
        {
            PauseOverlay = new Basic2d("Pause", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2), new Vector2(300,300));
            Font = Global.Content.Load<SpriteFont>("Fonts//Arial16");
            //resetBtn = new Button2d("Button", new Vector2(0,0), new Vector2(96,32), "Fonts//Arial16", "Reset", RESET, null);
            HealthBar = new QuantityDisplayBar(new Vector2(104,16), 2, Color.Red);
            HealthTowerBar = new QuantityDisplayBar(new Vector2(104,16), 2, Color.YellowGreen);
            WeaponBar = new Basic2d("StatusPanelSword", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350,100));
        }
        public void Update(World world)
        {
            HealthBar.Update(world.User.Hero.Health, world.User.Hero.HealthMax);
            if(world.User.Buildings.FirstOrDefault() != null)
                HealthTowerBar.Update(world.User.Buildings.FirstOrDefault().Health, world.User.Buildings.FirstOrDefault().HealthMax);

            if (world.User.Hero.OwnerProjectiles[1] && !world.User.Hero.OwnerProjectiles[2])
                WeaponBar = new Basic2d("StatusPanelSwordArrow", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));
            if (world.User.Hero.OwnerProjectiles[1] && world.User.Hero.OwnerProjectiles[2])
                WeaponBar = new Basic2d("StatusPanelSwordArrowCrossbow", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));

            if (world.User.Hero.OwnerProjectiles[1] && world.User.Hero.CostArrowTower <= GameGlobal.Score && !world.User.Hero.OwnerProjectiles[2])
                WeaponBar = new Basic2d("StatusPanelSwordArrowTurel", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));
            if(world.User.Hero.OwnerProjectiles[1] && world.User.Hero.CostArrowTower <= GameGlobal.Score && !world.User.Hero.OwnerProjectiles[2])
                WeaponBar = new Basic2d("StatusPanelSwordArrowCrossbowTurel", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));

            if(world.User.Hero.CostArrowTower <= GameGlobal.Score && !world.User.Hero.OwnerProjectiles[1] && !world.User.Hero.OwnerProjectiles[2])
                WeaponBar = new Basic2d("StatusPanelSwordTurel", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));
            if (world.User.Hero.CostArrowTower <= GameGlobal.Score && world.User.Hero.OwnerProjectiles[1] && !world.User.Hero.OwnerProjectiles[2])
                WeaponBar = new Basic2d("StatusPanelSwordArrowTurel", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));
            if (world.User.Hero.CostArrowTower <= GameGlobal.Score && !world.User.Hero.OwnerProjectiles[1] && world.User.Hero.OwnerProjectiles[2])
                WeaponBar = new Basic2d("StatusPanelSwordCrossbowTurel", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));
            if (world.User.Hero.CostArrowTower <= GameGlobal.Score && world.User.Hero.OwnerProjectiles[1] && world.User.Hero.OwnerProjectiles[2])
                WeaponBar = new Basic2d("StatusPanelSwordArrowCrossbowTurel", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));

        }

        public void Draw(World world)
        {
            Global.NormalEffect.Parameters["xSize"].SetValue(1.0f);
            Global.NormalEffect.Parameters["ySize"].SetValue(1.0f);
            Global.NormalEffect.Parameters["xDraw"].SetValue(1.0f);
            Global.NormalEffect.Parameters["yDraw"].SetValue(1.0f);
            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();


            var tempStr = "Score: " + GameGlobal.Score;
            var strDims = Font.MeasureString(tempStr);
            Global._spriteBatch.DrawString(Font, 
                tempStr, 
                new Vector2(Global.ScreenWidth / 2 - strDims.X / 2, 40), 
                Color.Black);

            tempStr = "All kills:" + GameGlobal.TotalScore;
            strDims = Font.MeasureString(tempStr);
            Global._spriteBatch.DrawString(Font,
                tempStr,
                new Vector2(Global.ScreenWidth / 2 - strDims.X / 2,  80),
                Color.Black);

            tempStr = "Costs:";
            strDims = Font.MeasureString(tempStr);
            Global._spriteBatch.DrawString(Font,
                tempStr,
                new Vector2(Global.ScreenWidth / 2 - 250, Global.ScreenHeight - 60),
                Color.Black);

            tempStr = (world.User.Hero.CostArrowTower).ToString();
            strDims = Font.MeasureString(tempStr);
            Global._spriteBatch.DrawString(Font,
                tempStr,
                new Vector2(Global.ScreenWidth / 2 - strDims.X / 2 + 70, Global.ScreenHeight - 60),
                Color.Black);

            if (!world.User.Hero.OwnerProjectiles[1] )
            {
                tempStr = world.User.Hero.CostBow.ToString();
                strDims = Font.MeasureString(tempStr);
                Global._spriteBatch.DrawString(Font,
                    tempStr,
                    new Vector2(Global.ScreenWidth / 2 - strDims.X / 2 - 70, Global.ScreenHeight - 60),
                    Color.Black);
            }

            if (!world.User.Hero.OwnerProjectiles[2])
            {
                tempStr = world.User.Hero.CostCrossBow.ToString();
                strDims = Font.MeasureString(tempStr);
                Global._spriteBatch.DrawString(Font,
                    tempStr,
                    new Vector2(Global.ScreenWidth / 2 - strDims.X / 2, Global.ScreenHeight - 60),
                    Color.Black);
            }



            /*tempStr = "Turret cost:" + world.User.Hero.CostArrowTower;
            strDims = Font.MeasureString(tempStr);
            Global._spriteBatch.DrawString(Font,
                tempStr,
                new Vector2(Global.ScreenWidth / 2 - strDims.X / 2, 120),
                Color.Black);

            if (!world.User.Hero.OwnerProjectiles[1])
            {
                tempStr = "Arrow cost:" + 10;
                strDims = Font.MeasureString(tempStr);
                Global._spriteBatch.DrawString(Font,
                    tempStr,
                    new Vector2(Global.ScreenWidth / 2 - strDims.X / 2, 140),
                    Color.Black);
            }*/



            if (world.User.Hero.IsDead || world.User.Buildings.Count <= 0)
            {
                tempStr = "Press and hold Enter to Restart!";
                strDims = Font.MeasureString(tempStr);
                Global._spriteBatch.DrawString(Font,
                    tempStr,
                    new Vector2(Global.ScreenWidth / 2 - strDims.X / 2, 100),
                    Color.DarkRed);
                //resetBtn.Draw(new Vector2(Global.screenWidth / 2 , 200));
            }

            HealthBar.Draw(new Vector2(20, Global.ScreenHeight - 40));
            HealthTowerBar.Draw(new Vector2(20, Global.ScreenHeight - 60));
            WeaponBar.Draw(Vector2.Zero);

            if (GameGlobal.Paused)
                PauseOverlay.Draw(Vector2.Zero);
        }
    }
}
