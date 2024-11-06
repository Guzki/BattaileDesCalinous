using System.Runtime.CompilerServices;

namespace BattaileDesCalinous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item();
            Console.WriteLine(item.name);
            Console.WriteLine(item.buffAmount);
            Console.WriteLine(item.healAmount);

            Player player = new Player();
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
    }
}
