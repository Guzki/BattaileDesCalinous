﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattaileDesCalinous
{
    public class Monster
    {
        public string Name;
        public int health;
        public int attackPower;
        private Random r;

        public Monster()
        {
            r = new Random();

            var type = r.Next(3);
            if(type == 0)
            {
                Name = "Ourson";
                health = 40;
                attackPower = 10;
            }
            else if (type == 1)
            {
                Name = "Charmander";
                health = 20;
                attackPower = 30;
            }
            else if (type == 2)
            {
                Name = "Cornichon";
                health = 30;
                attackPower = 15;
            }
        }

        public void attack(Player player)
        {
            //Damage to Player 
            //damage = damage power - player defense
            int damage = attackPower - player.defensePower;
            player.health = player.health - damage;
            player.updatePlayerStatus();

        }

		public override string ToString()
		{
			return Name;
		}
    }
}
