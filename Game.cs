using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattaileDesCalinous
{
	public class Game
	{
		public Player player;
		public bool isRunning;
		private Random random;

		public Game() {
			player = new Player("DefaultName");
			isRunning = true;
			random = new Random();
		}

		public void start()
		{
			Console.WriteLine("#######Battailles de Bestiolles#######");
			Console.WriteLine("Jeu créer par le club de Codage Franco-Niagara");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Tu es perdu dans un labirinthe sans fin. Comment longtemps peux tu survivre");
			Console.WriteLine();
			Console.WriteLine("Quel est ton nom?");
			string nom = Console.ReadLine();
			player.name = nom;
			Console.WriteLine(player);
		}

		public void end() 
		{
		
		}

		public void load()
		{

		}

		public void save()
		{

		}

		public void playRound()
		{
			Console.Clear();
			Console.WriteLine(player);
			Console.WriteLine();
			entrerDansUneSalle();
		}

		private void entrerDansUneSalle()
		{
			int num = random.Next(100);

			if(num < 50)
			{
				salleDeMonstre();
			} else if (num < 90)
			{
				salleDItem();
			} else
			{
				salleDePet();
			}
		}

		private void salleDePet()
		{
			Console.WriteLine("Tu est entrez dans une salle avec une bestiolle.");
			Console.ReadKey(true);
		}

		private void salleDItem()
		{
			Console.WriteLine("Tu est entrez dans une salle avec un item.");
			Item item = new Item();
			player.pickUpItem(item);
			Console.WriteLine($"Tu as ramasser une {item.name}");
			Console.WriteLine("Touche une clès pour continuer.");
			Console.ReadKey(true);
		}

		private void salleDeMonstre()
		{
			Monster monster = new Monster();
			Console.WriteLine($"Tu est entrez dans une salle avec un {monster.Name}.");


			while (monster.health > 0)
			{
				Console.WriteLine("Veux tu:");
				Console.WriteLine($"1 - Attacker avec {player.currentPet.name}");
				Console.WriteLine($"2 - Donner une potion a {player.currentPet.name}");
				Console.WriteLine("3 - Changer de pet");

				int reponse;
				while (true)
				{
					try
					{
						reponse = Convert.ToInt16(Console.ReadLine());
						if (reponse > 0 && reponse <= 3) break;
						else Console.WriteLine("Entrez une réponse valide.");
					}
					catch (Exception e)
					{
						Console.WriteLine("Entrez une réponse valide.");
					}
				}

				switch (reponse)
				{
					case 1:
						Console.WriteLine($"{player.currentPet.name} attack {monster.Name} pour {player.currentPet.attackPower} domage.");
						player.currentPet.attack(monster);
						break;
					case 2:
						break;
					case 3:
						break;
				}




			}


			Console.ReadKey(true);
		}
	}
}
