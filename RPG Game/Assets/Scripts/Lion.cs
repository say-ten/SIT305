namespace RPGGame
{
    public class Lion : Monster
    {
        internal void Start()
        {
            Description = "Lion";
            Health = 30;
            MaxHealth = 40;
            Attack = 15;
            Defence = 10;
            Inventory.Add("Lion monster core");
            Inventory.Add("Green Gem");
        }
    }
}