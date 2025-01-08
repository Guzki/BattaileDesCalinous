using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattaileDesCalinous
{
	public class Player
	{
		public string name;
		public List<Item> items;
		public List<Pet> pets;
		public Pet currentPet;
		public int score;

		public Player(string name)
		{
			this.name = name;
			items = new List<Item>();
			pets = new List<Pet>();
			currentPet = new Pet("Rat Child");
			pets.Add(currentPet);
			score = 0;
		}

		public override string ToString()
		{
			return $"{name}\n" +
				$"Pets: {pets.Count}\n"+
				$"Items: {items.Count}\n" +
				$"Current Pet: {currentPet.name}\n" +
				$"Score: {score}";
		}

		public void AddPet(Pet pet) {
			pets.Add(pet);
		}

		public void ChangePet(Pet pet)
		{
			currentPet = pet;
		}

		public void GiveItem(Item item, Pet pet)
		{
			pet.useItem(item);
			items.Remove(item);

		}

		public void pickUpItem(Item item)
		{
			items.Add(item);
		}
	}
}
