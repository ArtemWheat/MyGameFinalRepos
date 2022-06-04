using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MyGame1
{
    public class Player
    {
        public int Id { get; }
        public List<Unit> Units { get; }
        public Hero Hero { get; set; }
        public List<SpawnPoint> SpawnPoints{ get; set; }
        public List<Building> Buildings { get; set; }

        public Player(int id)
        {
            Id = id;
            Units = new List<Unit>();
            SpawnPoints = new List<SpawnPoint>();
            Buildings = new List<Building>();
           
        }

        public void Update(Player enemy, Vector2 offset)
        {
            if(Hero != null)
             Hero.Update(offset);

            for (var i = 0; i < SpawnPoints.Count; i++)
            {
                SpawnPoints[i].Update(offset);
                if (SpawnPoints[i].IsDead)
                {
                    SpawnPoints.RemoveAt(i);
                    i--;
                }
            }

            for (var i = 0; i < Units.Count; i++)
            {
                Units[i].Update(offset, enemy);
                if (Units[i].IsDead)
                {
                    World.DeadTraces.Add(new DeadTrace("Dead", Units[i].Pos, new Vector2(100,100)));
                    if (Units[i].Name == "Spider")
                        ChangeScore(5);
                    else
                        ChangeScore(3);

                    GameGlobal.TotalScore++;
                    Units.RemoveAt(i);

                    i--;
                }
            }

            for (var i = 0; i < Buildings.Count; i++)
            {
                Buildings[i].Update(offset, enemy);
                if (Buildings[i].IsDead)
                {
                    Buildings.RemoveAt(i);
                    i--;
                }
            }
        }

        public void AddBuilding(object info)
        {
            var tempBuilding = (Building)info;
            tempBuilding.OwnerId = Id;
            Buildings.Add((Building)info);
        }

        public void AddUnit(object info)
        {
            var tempUnit = (Unit)info;
            tempUnit.OwnerId = Id;
            Units.Add((Unit)info);
        }

        public void AddSpawnPoint(object info)
        {
            var tempSpawnPoint = (SpawnPoint)info;
            tempSpawnPoint.OwnerId = Id;
            SpawnPoints.Add(tempSpawnPoint);
        }

        public virtual void ChangeScore(int score)
        {

        }

        public List<AttackableObject> GetAllObjects()
        {
            var tempObjects = new List<AttackableObject>();
            tempObjects.AddRange(Units.ToList<AttackableObject>());
            tempObjects.AddRange(SpawnPoints.ToList<AttackableObject>());
            tempObjects.AddRange(Buildings.ToList<AttackableObject>());
            return tempObjects;
        }

        public void Draw(Vector2 offset)
        {
            

            for (var i = 0; i < SpawnPoints.Count; i++)
            {
                SpawnPoints[i].Draw(offset);
            }

            for (var i = 0; i < Buildings.Count; i++)
            {
                if (Buildings[i].Pos.Y > Hero.Pos.Y)
                {
                    if (Hero != null)
                        Hero.Draw(offset);
                    Buildings[i].Draw(offset);
                }
                else
                {
                    Buildings[i].Draw(offset);
                    if (Hero != null)
                        Hero.Draw(offset);
                }
            }

            if (Hero != null)
                Hero.Draw(offset);

            for (var i = 0; i < Units.Count; i++)
            {
                Units[i].Draw(offset);
            }
        }
    }
}
