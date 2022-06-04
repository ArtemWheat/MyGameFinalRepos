using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MyGame1
{ 
    public class World
    {
        public Vector2 Offset { get; set; }
        public User User { get; }

        private readonly UI ui;
        private readonly List<Projectile2d> projectiles;
        private readonly List<AttackableObject> allObjects;
        private readonly PassObject ResetWorld;
        private readonly PassObject ChangeGameState;
        private readonly AIPlayer aiPlayer;
        private readonly Tiles tiles;
        public static List<DeadTrace> DeadTraces { get; set; }



        public World(PassObject ResetWorld, PassObject ChangeGameState)
        {
            DeadTraces = new List<DeadTrace>();
            this.ResetWorld = ResetWorld;
            this.ChangeGameState = ChangeGameState;
            GameGlobal.PassProjectile = AddProjectile;
            GameGlobal.PassMobs = AddMob;
            GameGlobal.CheckScroll = CheckScroll;
            GameGlobal.PassSpawnPoint = AddSpawnPoint;
            GameGlobal.PassBuilding = AddBuilding;
            GameGlobal.Paused = false;
            projectiles = new List<Projectile2d>();
            allObjects = new List<AttackableObject>();
            User = new User(1);
            aiPlayer = new AIPlayer(2);
            Offset = Vector2.Zero;
            ui = new UI();
            tiles = new Tiles();
        }

        public virtual void Update()
        {
            
            if (!User.Hero.IsDead && User.Buildings.Count > 0 && !GameGlobal.Paused)
            {
                allObjects.Clear();
                allObjects.AddRange(User.GetAllObjects());
                allObjects.AddRange(aiPlayer.GetAllObjects());

                aiPlayer.Update(User, Offset);
                User.Update(aiPlayer, Offset);

                for (var i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(Offset, allObjects);
                    if (projectiles[i].Done)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }

                
            }
            else if (Global.Keyboard.GetPress("Enter") && (User.Hero.IsDead || User.Buildings.Count <= 0))
            {
                GameGlobal.Score = 0;
                GameGlobal.TotalScore = 0;
                ResetWorld(null);
            }

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

            ui.Update(this);
        }

        public void AddMob(object INFO)
        {
            var tempUnit = (Unit)INFO;

            if (User.Id == tempUnit.OwnerId)
                User.AddUnit(tempUnit);

            else if (aiPlayer.Id == tempUnit.OwnerId)
                aiPlayer.AddUnit(tempUnit);
        }

        public void AddBuilding(object INFO)
        {
            var tempBuilding = (Building)INFO;

            if (User.Id == tempBuilding.OwnerId)
                User.AddBuilding(tempBuilding);

            else if (aiPlayer.Id == tempBuilding.OwnerId)
                aiPlayer.AddBuilding(tempBuilding);
        }

        public void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);

        }
        
        public void AddSpawnPoint(object INFO)
        {
            var tempSpawnPoint = (SpawnPoint)INFO;

            if (User.Id == tempSpawnPoint.OwnerId)
                User.AddUnit(tempSpawnPoint);

            else if (aiPlayer.Id == tempSpawnPoint.OwnerId)
                aiPlayer.AddSpawnPoint(tempSpawnPoint);

           
        }

        public void CheckScroll(object INPUT)
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

        public void Draw(Vector2 OFFSET)
        {
            tiles.Draw(Offset);
            for (var i = 0; i < DeadTraces.Count; i++)
            {
                DeadTraces[i].Draw(Offset);
            }
            for (var i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(Offset);
            }
            aiPlayer.Draw(Offset);
            User.Draw(Offset);
            ui.Draw(this);
        }

    }
}
