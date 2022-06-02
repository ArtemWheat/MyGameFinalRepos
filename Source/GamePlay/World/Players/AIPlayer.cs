﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class AIPlayer : Player
    {
        public AIPlayer(int id) : base(id)
        {
            SpawnPoints.Add(new Portal(new Vector2(50, 50), Id));
            SpawnPoints.Add(new Portal(new Vector2(Global.ScreenWidth / 2, Global.ScreenHeight - 50), Id));

            SpawnPoints[SpawnPoints.Count - 1].SpawnTimer.AddToTimer(500);

            SpawnPoints.Add(new Portal(new Vector2(Global.ScreenWidth - 50, 50), Id));

            SpawnPoints[SpawnPoints.Count - 1].SpawnTimer.AddToTimer(1000);
        }

        public virtual void Update(AIPlayer enemy, Vector2 offset)
        {
            base.Update(enemy, offset);
        }

        /*public override void AddUnit(object INFO)
        {
            units.Add((Unit)INFO);
        }*/

        public override void ChangeScore(int score)
        {
            GameGlobal.Score += score;
        }
    }
}