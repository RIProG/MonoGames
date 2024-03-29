﻿#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace TopDownShooter
{
    public class Spiderling : Mob
    {

        public McTimer spawnTimer;

        public Spiderling(Vector2 POS, int OWNERID)
            : base("2d\\Units\\Mobs\\Spider", POS, new Vector2(25, 25), OWNERID)
        {
            speed = 2.5f;

        }

        public override void Update(Vector2 OFFSET, Player ENEMY)
        {

            base.Update(OFFSET, ENEMY);
        }

        public override void AI(Player ENEMY)
        {
            Building temp = null;
            for (int i = 0; i < ENEMY.buildings.Count; i++)
            {
                if (ENEMY.buildings[i].GetType().ToString() == "TopDownShooter.Tower") //Namespace.Class
                {
                    temp = ENEMY.buildings[i];
                }
            }

            if (temp != null) // Error check to avoid crash
            {
                pos += Globals.RadialMovement(temp.pos, pos, speed);
                rot = Globals.RotateTowards(pos, temp.pos);

                if (Globals.GetDistance(pos, temp.pos) < 15)
                {
                    temp.GetHit(1);
                    dead = true;
                }

            }



        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
