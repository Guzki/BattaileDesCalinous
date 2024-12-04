using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattaileDesCalinous
{
	internal class Game
	{
		public Player player;
		public bool isRunning;

		public Game() {
			player = new Player("DefaultName");
			isRunning = true;
		}

		public void start()
		{
			Console.WriteLine("#######Battailles de Bestiolles sans bestiolles#######");
			Console.WriteLine("Jeu créer par le club de Codage Franco-Niagara");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Tu es perdu dans un labirinthe sans fin. Comment longtemps peux tu survivre");
			Console.WriteLine();
			Console.WriteLine("Quel est ton nom?");
			string nom = Console.ReadLine();
			player.name = nom;
			player.updatePlayerStatus();
			Console.WriteLine(player.status);
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
			throw new NotImplementedException();
		}
	}
}
