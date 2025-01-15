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
			//Choisie le type de salle dans lequel le joueur rentre
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


			while (monster.health > 0 && player.currentPet.health > 0)
			{
				Console.Clear();
				Console.WriteLine(player);
				Console.WriteLine();
				Console.WriteLine(player.currentPet.name + "\nHP: " + player.currentPet.health + "\nAP: " + player.currentPet.attackPower);
				Console.WriteLine();
				Console.WriteLine(monster.Name + "\nHP: " + monster.health + "\nAP: " + monster.attackPower);
				Console.WriteLine();
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
						Item itemChoisi = ChoisirUnItem();
						if (itemChoisi != null)
						{
							player.GiveItem(itemChoisi, player.currentPet);

							//Donner la potion
							Console.WriteLine($"Tu donnes une {itemChoisi.name} à {player.currentPet.name}");
						}
						break;

					case 3:

						//Est-ce qu'on a plus que 1 pet
						if (player.pets.Count > 0)
						{
							Pet newPet = ChoisirUnPet();
							player.ChangePet(newPet);
							Console.WriteLine($"Ta nouvelle bestiole est {player.currentPet}");
							//changer
						}
						else
						{
							Console.WriteLine("Tu ne peux pas changer de bestiole.");
						}
						break;
				}

				monster.attack(player.currentPet);
				Console.WriteLine($"{monster} attack {player.currentPet.name} pour {monster.attackPower} points de dommage.");

				//est-ce que le pet est mort
				if (player.currentPet.health <= 0)
				{
					if (!playerIsDead())
					{
						Pet pet = ChoisirUnPet();
						player.ChangePet(pet);
					}
					else
					{
						Console.WriteLine("Tous tes bestiolles sont morte....");
						isRunning = false;
					}
				}

				Console.WriteLine("Appuie sur une touche pour continuer.");
				Console.ReadKey(true);
			}


			Console.ReadKey(true);
		}

		private bool playerIsDead()
		{
			foreach (Pet pet in player.pets)
			{
				if (pet.health > 0)
				{
					return false;
				}
			}
			return true;
		}

		private Item ChoisirUnItem()
		{
			//Check si tu as des potions
			if (player.items.Count == 0)
			{
				Console.WriteLine("Tu n'as pas de potions.");
				return null;
			}
			else
			{
				//Choisi le potion
				Console.WriteLine("Quelle potion veux-tu donner?");
				//imprimer tous les potions
				for (int i = 1; i <= player.items.Count; i++)
				{
					Console.WriteLine($"   {i} - {player.items[i - 1].name}");
				}

				//Choisir une potion
				int reponse;
				while (true)
				{
					try
					{
						reponse = Convert.ToInt16(Console.ReadLine());
						if (reponse > 0 && reponse <= player.items.Count) break;
						Console.WriteLine("Entrez une réponse valide.");

					}
					catch (Exception e)
					{
						Console.WriteLine("Entrez une réponse valide.");
					}
				}

				return player.items[reponse - 1];
			}
		}

		private Pet ChoisirUnPet()
		{
				//Choisi le pet
				Console.WriteLine("Quelle bestiole veux-tu changer?");
				//imprimer tous les potions
				for (int i = 1; i <= player.pets.Count; i++)
				{
					Console.WriteLine($"   {i} - {player.pets[i - 1].name} : {player.pets[i-1].health} HP");
				}

				//Choisir une potion
				int reponse;
				while (true)
				{
					try
					{
						reponse = Convert.ToInt16(Console.ReadLine());
						if (reponse > 0 && reponse <= player.pets.Count) break;
						Console.WriteLine("Entrez une réponse valide.");

					}
					catch (Exception e)
					{
						Console.WriteLine("Entrez une réponse valide.");
					}
				}

				return player.pets[reponse - 1];
			
		}
	}
}
