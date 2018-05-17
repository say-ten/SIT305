namespace RPGGame
{
    using UnityEngine;

    public class Chest : MonoBehaviour
    {
        public Monster Monster { get; set; }

        public string Item { get; set; }

        public bool Trap { get; set; }

        public bool Potion { get; set; }

        public Chest()
        {
            Monster = Random.Range(0, 5) == 2 ? MonsterDatabase.Instance.GetRandomMonster() : null;
            Trap = Random.Range(0, 7) == 2;
            if (Random.Range(0, 9) == 0)
            {
                Trap = true;
            }
            else if (Random.Range(0, 4) == 0)
            {
                Potion = true;
            }
            else if (Random.Range(0, 2) == 0)
            {
                Monster = MonsterDatabase.Instance.GetRandomMonster();
            }
            else if (Random.Range(0, 49) == 0)
            {
                Item = ItemDatabase.Instance.Items[0];
            }
        }
    }
}