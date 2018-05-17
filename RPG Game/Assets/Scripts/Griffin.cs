namespace RPGGame
{
    public class Griffin : Monster
    {
        internal void Start()
        {
            Description = "Griffin";
            Health = 30;
            MaxHealth = 30;
            Attack = 10;
            Defence = 10;
            Inventory.Add("Griffin monster core");
            Inventory.Add("Blue Gem");
        }
    }
}