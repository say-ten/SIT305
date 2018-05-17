namespace RPGGame
{
    public class Lion : Monster
    {
        internal void Start()
        {
            Description = "Lion";
            Health = 40;
            MaxHealth = 40;
            Attack = 12;
            Defence = 7;
            Inventory.Add("Lion monster core");
            Inventory.Add("Green Gem");
        }
    }
}