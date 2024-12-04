using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BattaileDesCalinous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.start();
            while (game.isRunning)
            {
                game.playRound();
            }
            game.end();
        }

        /// <summary>
        /// Cette fonction test système d'inventaire du joueur. 
        /// Un joueur est créé.
        /// Il ramasse 3 items.
        /// Il consomme 3 items.
        /// The status est affiché après chaque exécution. 
        /// </summary>
        private static void PlayerTest()
        {
            Player player = new Player("Greg");
            Console.WriteLine(player.status);

            Item i = new Item();
            player.pickUpItem(i);
            Console.WriteLine(player.status);

            Item i2 = new Item();
            player.pickUpItem(i2);
            Console.WriteLine(player.status);

            Item i3 = new Item();
            player.pickUpItem(i3);
            Console.WriteLine(player.status);

            player.useItem(i3);
            Console.WriteLine(player.status);

            player.useItem(i2);
            Console.WriteLine(player.status);

            player.useItem(i);
            Console.WriteLine(player.status);

        }

        /// <summary>
        /// Cette fonction test la class Item.
        /// Un Item est créé et donné à un joueur qui en suite l'utilise. 
        /// </summary>
        static void ItemTest()
        {
            Item item = new Item();
            Console.WriteLine(item.name);
            Console.WriteLine(item.buffAmount);
            Console.WriteLine(item.healAmount);

            Player player = new Player("Big Dude");
            Console.WriteLine("Joueur:");
            Console.WriteLine(player.health);
            Console.WriteLine(player.attackPower);
            Console.WriteLine(player.defensePower);

            Console.WriteLine("Le joueur boit la potion");
            item.applyEffect(player);
            Console.WriteLine("Joueur:");
            Console.WriteLine(player.health);
            Console.WriteLine(player.attackPower);
            Console.WriteLine(player.defensePower);
        }


        static void MonsterPlayerAttackTest()
        {
            //Create a joueur
            Player player = new Player("Winner");
            //Create un monster
            Monster monster = new Monster();

            Console.WriteLine(monster);

            //status
            Console.WriteLine(player.status);
            Console.WriteLine($"Monster Health: {monster.health}");

            //joueur attack
            Console.WriteLine("Player is attacking monster.");
            player.attack(monster);

			Console.WriteLine(player.status);
			Console.WriteLine($"Monster Health: {monster.health}");
            //status

            //monster attack
            monster.attack(player);

            //status
            Console.WriteLine("Monster is attacking player;");
			Console.WriteLine(player.status);
			Console.WriteLine($"Monster Health: {monster.health}");
		}


    }
}
