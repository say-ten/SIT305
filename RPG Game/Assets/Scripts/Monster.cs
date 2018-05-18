namespace RPGGame
{
    public interface IBaddie
    {
        void Cry();
        string Description { get; set; }
    }

    public class Monster : Character
    {
        //public modifiers the monsters
        public string Description { get; set; }
        public override void Attacked(int hp)
        {
            base.Attacked(hp);
            UIController.OnMonsterUpdate(this);
        }

        public void Cry()
        {
        }

        //when monsters die, it will display text output in game
        //will load pickup functions for adding items and also reset monster health to full
        public override void Dead()
        {
            Console.Instance.Entry("You have killed the monster");
            Interactions.OnMonsterDead();
            Health = MaxHealth;
        }
    }
}