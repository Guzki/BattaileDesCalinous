
namespace BattaileDesCalinous
{
    internal class Player
    {
        internal int health;
        internal int attackPower;
        internal int defensePower;
        internal string? name;
        internal int score;
        internal List<Item> items;
        internal string status;


        public Player(string? name) 
        {
            health = 100;
            attackPower = 10;
            defensePower = 0;
            this.name = name;
            items = new List<Item>();
            updatePlayerStatus();

        }

        private void updatePlayerStatus()
        {
            status = $"{name}\n" +
                $"Score: {score}\n" +
                $"Santé: {health}\n" +
                $"Attack: {attackPower}\n" +
                $"Defense: {defensePower}\n" +
                $"Items: {items.Count}\n";

            if (items.Count > 0)
            {
                foreach (Item item in items)
                {
                    status += item.name + "\n";
                }
            }
        }

        public void pickUpItem(Item item)
        {
            items.Add(item);
            updatePlayerStatus();
        }

        public void useItem(Item item) 
        {
            //apply Effect
            item.applyEffect(this);
            //get rid of it
            items.Remove(item);
            //update status
            updatePlayerStatus();
        }
    }
}