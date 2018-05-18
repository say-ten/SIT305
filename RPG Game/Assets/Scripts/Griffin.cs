namespace RPGGame
{
    public class Griffin : Monster
    {
        //loading all the stats and items for monster griffin
        internal void Start()
        {
            Description = "Griffin";
            Health = 30;
            MaxHealth = 30;
            Attack = 20;
            Defence = 5;
            Inventory.Add("Griffin monster core");
            Inventory.Add("Blue Gem");
        }
    }
}