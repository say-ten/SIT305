namespace RPGGame
{
    public class Boar : Monster
    {
        //loading all the stats and items for monster boar
        internal void Start()
        {
            Description = "Boar";
            Health = 30;
            MaxHealth = 30;
            Attack = 10;
            Defence = 10;
            Inventory.Add("Boar monster core");
            Inventory.Add("Yellow Gem");
        }
    }
}