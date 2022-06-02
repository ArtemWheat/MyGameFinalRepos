using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame1
{
    public class Player
    {
        public int Id;
        public List<Unit> units = new List<Unit>();
        public Hero Hero;
        public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();
        public List<Building> Buildings = new List<Building>();

        public Player(int id)
        {
            Id = id;
        }

        public virtual void Update(Player enemy, Vector2 offset)
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

            for (var i = 0; i < units.Count; i++)
            {
                units[i].Update(offset, enemy);
                if (units[i].IsDead)
                {
                    if (units[i].Name == "Spider")
                        ChangeScore(5);
                    else
                        ChangeScore(3);

                    GameGlobal.TotalScore++;
                    units.RemoveAt(i);

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

        public virtual void AddBuilding(object info)
        {
            var tempBuilding = (Building)info;
            tempBuilding.OwnerId = Id;
            Buildings.Add((Building)info);
        }

        public virtual void AddUnit(object info)
        {
            var tempUnit = (Unit)info;
            tempUnit.OwnerId = Id;
            units.Add((Unit)info);
        }

        public virtual void AddSpawnPoint(object info)
        {
            var tempSpawnPoint = (SpawnPoint)info;
            tempSpawnPoint.OwnerId = Id;
            SpawnPoints.Add(tempSpawnPoint);
        }

        public virtual void ChangeScore(int score)
        {

        }

        public virtual List<AttackableObject> GetAllObjects()
        {
            var tempObjects = new List<AttackableObject>();
            tempObjects.AddRange(units.ToList<AttackableObject>());
            tempObjects.AddRange(SpawnPoints.ToList<AttackableObject>());
            tempObjects.AddRange(Buildings.ToList<AttackableObject>());
            return tempObjects;
        }

        public virtual void Draw(Vector2 offset)
        {
           

            for (var i = 0; i < SpawnPoints.Count; i++)
            {
                SpawnPoints[i].Draw(offset);
            }

            for (var i = 0; i < Buildings.Count; i++)
            {
                Buildings[i].Draw(offset);
            }

            for (var i = 0; i < units.Count; i++)
            {
                units[i].Draw(offset);
            }

            if (Hero != null)
                Hero.Draw(offset);


        }
    }
}
