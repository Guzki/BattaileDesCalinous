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
        /// Cette fonction test la class Item.
        /// Un Item est créé et donné à un joueur qui en suite l'utilise. 
        /// </summary>
        static void ItemTest()
        {
            Item item = new Item();
            Console.WriteLine(item.name);
            Console.WriteLine(item.buffAmount);
            Console.WriteLine(item.healAmount);

            Pet player = new Pet("Big Dude");
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
            Pet player = new Pet("Winner");
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
