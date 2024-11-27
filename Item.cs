using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BattaileDesCalinous
{
	public class Item
    {
        public string name;
        public int buffAmount;
        public int healAmount;

        public Item()
        {
            Random random = new Random();

            if(random.Next(2) == 0)
            {
                buffAmount = 0;
                healAmount = 10;
                name = "Potion de vie";
            } else
            {
                buffAmount = 2;
                healAmount = 0;
                name = "Potion de Géant";
            }

        }

		public void applyEffect(Player player)
        {
            player.health += healAmount;
            player.attackPower += buffAmount;
            player.defensePower += buffAmount;
        }
    }
}
