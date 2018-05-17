namespace RPGGame
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UIController : MonoBehaviour
    {
        [SerializeField]
        internal Player player;

        [SerializeField]
        internal Text playerStatsText, monsterStatsText, playerInventoryText;

        public delegate void OnPlayerUpdateHandler();

        public static OnPlayerUpdateHandler OnPlayerStatChange;

        public static OnPlayerUpdateHandler OnPlayerInventoryChange;

        public delegate void OnMonsterUpdateHandler(Monster monster);

        public static OnMonsterUpdateHandler OnMonsterUpdate;

        internal void Start()
        {
            OnPlayerStatChange += UpdatePlayerStats;
            OnPlayerInventoryChange += UpdatePlayerInventory;
            OnMonsterUpdate += UpdateMonsterStats;
        }

        public void UpdatePlayerStats()
        {
            playerStatsText.text = string.Format("Player: {0} health, {1} attack, {2} defence", player.Health, player.Attack, player.Defence);
        }

        public void UpdatePlayerInventory()
        {
            playerInventoryText.text = "Items: ";
            foreach (string item in player.Inventory)
            {
                playerInventoryText.text += item + " / ";
            }
        }

        public void UpdateMonsterStats(Monster monster)
        {
            if (monster)
                monsterStatsText.text = string.Format("{0}: {1} health, {2} attack, {3} defence", monster.Description, monster.Health, monster.Attack, monster.Defence);
            else
                monsterStatsText.text = "";
        }
    }
}