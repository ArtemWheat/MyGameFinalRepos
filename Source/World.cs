using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame1
{ 
    public class World
    {
        public Vector2 Offset;
        public UI Ui;
        public List<Projectile2d> Projectiles = new List<Projectile2d>();
        public List<AttackableObject> AllObjects = new List<AttackableObject>();
        readonly PassObject ResetWorld;
        readonly PassObject ChangeGameState;
        public User User;
        public AIPlayer AiPlayer;
        public SquareGrid Grid;
        public Tiles Tiles;

        

        public World(PassObject ResetWorld, PassObject ChangeGameState)
        {
            this.ResetWorld = ResetWorld;
            this.ChangeGameState = ChangeGameState;
            GameGlobal.PassProjectile = AddProjectile;
            GameGlobal.PassMobs = AddMob;
            GameGlobal.CheckScroll = CheckScroll;
            GameGlobal.PassSpawnPoint = AddSpawnPoint;
            GameGlobal.PassBuilding = AddBuilding;
            GameGlobal.Paused = false;
            User = new User(1);
            AiPlayer = new AIPlayer(2);

            Offset = Vector2.Zero;

            Grid = new SquareGrid(new Vector2(25,25), new Vector2(-100, -100), new Vector2(1700, 1000));
            Ui = new UI(this.ResetWorld);
            Tiles = new Tiles();
            
        }

        public virtual void Update()
        {
            
            if (!User.Hero.IsDead && User.Buildings.Count > 0 && !GameGlobal.Paused)
            {
                AllObjects.Clear();
                AllObjects.AddRange(User.GetAllObjects());
                AllObjects.AddRange(AiPlayer.GetAllObjects());

                AiPlayer.Update(User, Offset);
                User.Update(AiPlayer, Offset);

                for (var i = 0; i < Projectiles.Count; i++)
                {
                    Projectiles[i].Update(Offset, AllObjects);
                    if (Projectiles[i].Done)
                    {
                        Projectiles.RemoveAt(i);
                        i--;
                    }
                }

                
            }
            else if (Global.Keyboard.GetPress("Enter") && (User.Hero.IsDead || User.Buildings.Count <= 0))
            {
                ResetWorld(null);
            }

            if (Grid != null)
                Grid.Update(Offset);

            if (Global.Keyboard.GetSinglePress("Back"))
            {
                ResetWorld(null);
                ChangeGameState(0);
            }


            if (Global.Keyboard.GetSinglePress("Tab"))
                ChangeGameState(1);


            if (Global.Keyboard.GetSinglePress("P"))
            {
                GameGlobal.Paused = !GameGlobal.Paused;
            }

            if (Global.Keyboard.GetSinglePress("G"))
            {
                Grid.showGrid = !Grid.showGrid;
            }

            Ui.Update(this);
        }

        public virtual void AddMob(object INFO)
        {
            var tempUnit = (Unit)INFO;

            if (User.Id == tempUnit.OwnerId)
                User.AddUnit(tempUnit);

            else if (AiPlayer.Id == tempUnit.OwnerId)
                AiPlayer.AddUnit(tempUnit);
        }

        public virtual void AddBuilding(object INFO)
        {
            var tempBuilding = (Building)INFO;

            if (User.Id == tempBuilding.OwnerId)
                User.AddBuilding(tempBuilding);

            else if (AiPlayer.Id == tempBuilding.OwnerId)
                AiPlayer.AddBuilding(tempBuilding);
        }

        public virtual void AddProjectile(object INFO)
        {
            Projectiles.Add((Projectile2d)INFO);

        }
        
        public virtual void AddSpawnPoint(object INFO)
        {
            var tempSpawnPoint = (SpawnPoint)INFO;

            if (User.Id == tempSpawnPoint.OwnerId)
                User.AddUnit(tempSpawnPoint);

            else if (AiPlayer.Id == tempSpawnPoint.OwnerId)
                AiPlayer.AddSpawnPoint(tempSpawnPoint);

           
        }

        public virtual void CheckScroll(object INPUT)
        {
            var tempPos = (Vector2)INPUT;
            if (tempPos.X < -Offset.X + (Global.ScreenWidth * .5f))
            {
                Offset = new Vector2(Offset.X + User.Hero.Speed * 2, Offset.Y);
            }

            if (tempPos.X > -Offset.X + (Global.ScreenWidth * .5f))
            {
                Offset = new Vector2(Offset.X - User.Hero.Speed * 2, Offset.Y);
            }

            if (tempPos.Y < -Offset.Y + (Global.ScreenHeight * .5f))
            {
                Offset = new Vector2(Offset.X, Offset.Y + User.Hero.Speed * 2);
            }

            if (tempPos.Y > -Offset.Y + (Global.ScreenHeight * .5f))
            {
                Offset = new Vector2(Offset.X, Offset.Y - User.Hero.Speed * 2);
            }
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            Tiles.Draw(Offset);
            Grid.DrawGrid(Offset);

            for (var i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Draw(Offset);
            }

            User.Draw(Offset);
            AiPlayer.Draw(Offset);
            Ui.Draw(this);
        }

    }
}
