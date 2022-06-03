using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace MyGame1
{
    public class UI
    {
        public SpriteFont Font;
        public Basic2d PauseOverlay;
        public QuantityDisplayBar HealthBar;
        public QuantityDisplayBar HealthTowerBar;
        public Basic2d WeaponBar;

        public UI()
        {
            PauseOverlay = new Basic2d("Pause", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight / 2), new Vector2(300,300));
            Font = Global.Content.Load<SpriteFont>("Fonts//Arial16");
            HealthBar = new QuantityDisplayBar(new Vector2(104,16), 2, Color.Red);
            HealthTowerBar = new QuantityDisplayBar(new Vector2(104,16), 2, Color.YellowGreen);
            EditWeaponBar("StatusPanelSword");
        }
        public void Update(World world)
        {
            HealthBar.Update(world.User.Hero.Health, world.User.Hero.HealthMax);
            if(world.User.Buildings.FirstOrDefault() != null)
                HealthTowerBar.Update(world.User.Buildings.FirstOrDefault().Health, world.User.Buildings.FirstOrDefault().HealthMax);

            if (world.User.Hero.OwnerProjectiles[1] && !world.User.Hero.OwnerProjectiles[2])
                EditWeaponBar("StatusPanelSwordArrow");
            if (world.User.Hero.OwnerProjectiles[1] && world.User.Hero.OwnerProjectiles[2])
                EditWeaponBar("StatusPanelSwordArrowCrossbow");
            if (world.User.Hero.OwnerProjectiles[1] && world.User.Hero.CostArrowTower <= GameGlobal.Score && !world.User.Hero.OwnerProjectiles[2])
                EditWeaponBar("StatusPanelSwordArrowTurel");
            if (world.User.Hero.OwnerProjectiles[1] && world.User.Hero.CostArrowTower <= GameGlobal.Score && !world.User.Hero.OwnerProjectiles[2])
                EditWeaponBar("StatusPanelSwordArrowCrossbowTurel");

            if (world.User.Hero.CostArrowTower <= GameGlobal.Score && !world.User.Hero.OwnerProjectiles[1] && !world.User.Hero.OwnerProjectiles[2])
                EditWeaponBar("StatusPanelSwordTurel");
            if (world.User.Hero.CostArrowTower <= GameGlobal.Score && world.User.Hero.OwnerProjectiles[1] && !world.User.Hero.OwnerProjectiles[2])
                EditWeaponBar("StatusPanelSwordArrowTurel");
            if (world.User.Hero.CostArrowTower <= GameGlobal.Score && !world.User.Hero.OwnerProjectiles[1] && world.User.Hero.OwnerProjectiles[2])
                EditWeaponBar("StatusPanelSwordCrossbowTurel");
            if (world.User.Hero.CostArrowTower <= GameGlobal.Score && world.User.Hero.OwnerProjectiles[1] && world.User.Hero.OwnerProjectiles[2])
                EditWeaponBar("StatusPanelSwordArrowCrossbowTurel");

        }

        private void EditWeaponBar(string path)
        {
            WeaponBar = new Basic2d(path, new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 100), new Vector2(350, 100));
        }

        public void Draw(World world)
        {
            Global.NormalEffect.Parameters["xSize"].SetValue(1.0f);
            Global.NormalEffect.Parameters["ySize"].SetValue(1.0f);
            Global.NormalEffect.Parameters["xDraw"].SetValue(1.0f);
            Global.NormalEffect.Parameters["yDraw"].SetValue(1.0f);
            Global.NormalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Global.NormalEffect.CurrentTechnique.Passes[0].Apply();

            DrawText("Score: " + GameGlobal.Score, new Vector2(Global.ScreenWidth / 2, 40), Color.Black);
            DrawText("All kills:" + GameGlobal.TotalScore, new Vector2(Global.ScreenWidth / 2 , 80), Color.Black);
            DrawText("Costs:", new Vector2(Global.ScreenWidth / 2 - 200, Global.ScreenHeight - 60), Color.Black);
            DrawText((world.User.Hero.CostArrowTower).ToString(), new Vector2(Global.ScreenWidth / 2 + 70, Global.ScreenHeight - 60), Color.Black);
            DrawText("0", new Vector2(Global.ScreenWidth / 2 - 140, Global.ScreenHeight - 60), Color.Black); 

            if (!world.User.Hero.OwnerProjectiles[1])
                DrawText(world.User.Hero.CostBow.ToString(), new Vector2(Global.ScreenWidth / 2 - 70, Global.ScreenHeight - 60), Color.Black);
            else
                DrawText("0", new Vector2(Global.ScreenWidth / 2 - 70, Global.ScreenHeight - 60), Color.Black);

            if (!world.User.Hero.OwnerProjectiles[2])
                DrawText(world.User.Hero.CostCrossBow.ToString(), new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 60), Color.Black);
            else
                DrawText("0", new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 60), Color.Black);

            if (world.User.Hero.IsDead || world.User.Buildings.Count <= 0)
                DrawText("Press and hold Enter to Restart!", new Vector2(Global.ScreenWidth / 2 , Global.ScreenHeight / 2), Color.Red);

            HealthBar.Draw(new Vector2(20, Global.ScreenHeight - 40));
            HealthTowerBar.Draw(new Vector2(20, Global.ScreenHeight - 60));
            WeaponBar.Draw(Vector2.Zero);

            if (GameGlobal.Paused)
                PauseOverlay.Draw(Vector2.Zero);
        }

        private void DrawText(string text, Vector2 posText, Color color)
        {
            Global._spriteBatch.DrawString(Font,
                text,
                new Vector2(posText.X - Font.MeasureString(text).X / 2, posText.Y),
                color);
        }
    }
}
