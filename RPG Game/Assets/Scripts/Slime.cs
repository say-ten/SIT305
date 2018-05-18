namespace RPGGame
{
    public class Slime : Monster
    {
        //loading all the stats and items for monster slime
        internal void Start()
        {
            Description = "Slime";
            Health = 20;
            MaxHealth = 20;
            Attack = 5;
            Defence = 5;
            Inventory.Add("Slime monster core");
            Inventory.Add("Red Gem");
        }
    }
}