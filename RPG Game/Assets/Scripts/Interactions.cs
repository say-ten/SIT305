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
            foreach(Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }

        public void StartFight()
        {
            this.Monster = player.Dungeon.Monster;
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
//            UIController.OnMonsterUpdate(this.Monster);
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
                player.Attacked(5);
                Console.Instance.Entry("Trap disguised as a chest, lost 5 health.");
            }
            else if (chest.Potion)
            {
                player.Attacked(-10);
                Console.Instance.Entry("Found a potion, gain 10 Health.");
            }
            else if (chest.Monster)
            {
                player.Dungeon.Monster = chest.Monster;
                player.Dungeon.Chest = null;
                Console.Instance.Entry("Monster jumped out of the box");
                player.Investigate();
            }
            player.Dungeon.Chest = null;
            dynamicControls[3].interactable = false;
        }

        public void Attack()
        {
            int playerDamageAmount = (int)(Random.value *(player.Attack - Monster.Defence));
            int monsterDamageAmount = (int)(Random.value * (Monster.Attack - player.Defence));
            Console.Instance.Entry("<color=#59ffa1>You dealt <b>" + playerDamageAmount + "</b> damage!</color>");
            Console.Instance.Entry("<color=#59ffa1>The monster attacked dealing <b>" + monsterDamageAmount + "</b> damage back!</color>");
            player.Attacked(monsterDamageAmount);
            Monster.Attacked(playerDamageAmount);
        }

        public void Flee()
        {
            int monsterDamageAmount = (int)(Random.value * (Monster.Attack - (player.Defence*.5f)));
            player.Dungeon.Monster = null;
//            UIController.OnMonsterUpdate(null);
            player.Attacked(monsterDamageAmount);
            Console.Instance.Entry("<color=#59ffa1>During the escape the monster dealt <b>" + monsterDamageAmount + "</b> damage!</color>");
            player.Investigate();
        }

        public void ExitFloor()
        {
            StartCoroutine(player.region.GenerateFloor());
            player.Floor += 1;
            Console.Instance.Entry("You found an exit to floor: " + player.Floor);
        }

        public void Pickup()
        {
            player.AddItem(this.Monster.Inventory[0]);
            Console.Instance.Entry(string.Format(
                "<color=#56FFC7FF>You've defeated {0}. Searching the remains, {1} found!</color>", 
                this.Monster.Description, this.Monster.Inventory[0]
            ));
            this.Monster = null;
            player.Investigate();
//            UIController.OnMonsterUpdate(this.Monster);
        }
    }
}
