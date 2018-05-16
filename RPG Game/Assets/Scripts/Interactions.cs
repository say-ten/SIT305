using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class Interactions : MonoBehaviour
    {
        public Monster Monster { get; set; }
        [SerializeField]
        Player player;

        [SerializeField]
        Button[] dynamicControls;

        public delegate void OnMonsterDeadHandler();
        public static OnMonsterDeadHandler OnMonsterDead;

        private void Start()
        {
            OnMonsterDead += Pickup;
        }

        public void ResetDynamicControls()
        {
            foreach (Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }

        public void StartFight()
        {
            this.Monster = player.Dungeon.Monster;
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
            UIController.OnMonsterUpdate(this.Monster);
        }

        public void StartChest()
        {
            dynamicControls[3].interactable = true;
        }

        public void StartExit()
        {
            dynamicControls[2].interactable = true;
        }

        public void OpenChest()
        {
            Chest chest = player.Dungeon.Chest;
            if (chest.Trap)
            {
                player.damageTaken(5);
                Console.Instance.Entry("It was a trap! You lost 5 health.");
            }
            else if (chest.Potion)
            {
                player.damageTaken(-20);
                Console.Instance.Entry("You found a potion! You gained 10 health.");
            }
            else if (chest.Monster)
            {
                player.Dungeon.Monster = chest.Monster;
                player.Dungeon.Chest = null;
                Console.Instance.Entry("A monster appeared!");
                player.Investigate();
            }
            else
            {
                player.AddItem(chest.Item);
                UIController.OnPlayerInventoryChange();
                Console.Instance.Entry("You found a " + chest.Item + "!");
            }
            player.Dungeon.Chest = null;
            dynamicControls[3].interactable = false;
        }

        public void Attack()
        {
            int playerDamageAmount = (int)(Random.value * (player.playerAttack - Monster.monsterDefence));
            int monsterDamageAmount = (int)(Random.value * (Monster.monsterAttack - player.playerDefence));
            Console.Instance.Entry("<color=#59ffa1>You dealt <b>" + playerDamageAmount + "</b> damage!</colour>");
            Console.Instance.Entry("<color=#59ffa1>The monster attacked, dealing <b>" + monsterDamageAmount + "</b> damage!</colour>");
            player.damageTaken(monsterDamageAmount);
            Monster.damageTaken(playerDamageAmount);
        }

        public void Escape()
        {
            int monsterDamageAmount = (int)(Random.value * (Monster.monsterAttack - (player.playerDefence * .5f)));
            player.Dungeon.Monster = null;
            UIController.OnMonsterUpdate(null);
            player.damageTaken(monsterDamageAmount);
            Console.Instance.Entry("<colour=#59ffa1>During your escape, the monster dealt <b>" + monsterDamageAmount + "</b> damage!</colour>");
            player.Investigate();
        }

        public void ExitFloor()
        {
            StartCoroutine(player.region.GenerateFloor());
            player.Floor += 1;
            Console.Instance.Entry("You found an exit to floor " + player.Floor + "!");
        }

        public void Pickup()
        {
            {
                int randomNumber = Random.Range(0, 3);
                player.AddItem(ItemDatabase.Instance.itemList[randomNumber]);
                Console.Instance.Entry(string.Format("<colour=#56FFC7FF>You've defeated {0}. Searching the remains, {1} found!</colour>",
                    this.Monster.Description, ItemDatabase.Instance.itemList[randomNumber]));
            }
            player.Dungeon.Monster = null;
            UIController.OnMonsterUpdate(null);
            player.Investigate();
        }
    }
}
