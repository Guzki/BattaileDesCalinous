
namespace BattaileDesCalinous
{
    public class Pet
    {
        public int health;
		public int attackPower;
		public int defensePower;
		public string? name;
		public int score;
		public string status;


        public Pet(string? name) 
        {
            health = 100;
            attackPower = 10;
            defensePower = 0;
            this.name = name;
            updatePlayerStatus();

        }

        public void updatePlayerStatus()
        {
            status = $"{name}\n" +
                $"Score: {score}\n" +
                $"Santé: {health}\n" +
                $"Attack: {attackPower}\n" +
                $"Defense: {defensePower}\n";

        }


        public void useItem(Item item) 
        {
            //apply Effect
            item.applyEffect(this);
            //update status
            updatePlayerStatus();
        }

        public void attack(Monster monster)
        {
            monster.health = monster.health - attackPower;
        }
    }
}