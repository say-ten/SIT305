namespace RPGGame
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Interactions : MonoBehaviour
    {
        public Monster Monster { get; set; }

        [SerializeField]
        internal Player player;
        [SerializeField]
        internal Button[] dynamicControls;

        public delegate void OnMonsterDeadHandler();
        public static OnMonsterDeadHandler OnMonsterDead;

        //checks roomindex at the start of game as well as after every action
        //if the monster dies it starts the pickup method
        private void Start()
        {
            player.Investigate();
            OnMonsterDead += Pickup;
        }

        //turns off all the dynamic controls
        public void ResetDynamicControls()
        {
            foreach (Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }

        //if a monster is found it will activate the required buttons to battle the monster
        //buttons activated are attack and flee
        public void StartFight()
        {
            this.Monster = player.Dungeon.Monster;
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
            UIController.OnMonsterUpdate(this.Monster);
        }

        //activated the open chest button
        public void StartChest()
        {
            dynamicControls[3].interactable = true;
        }

        //activates the escape button
        public void StartExit()
        {
            dynamicControls[2].interactable = true;
        }

        //method for deciding what happens for each item in chest as well as printing a console entry
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
                player.Attacked(-20);
                Console.Instance.Entry("Found a potion, gain 10 Health.");
            }
            else if (chest.Monster)
            {
                player.Dungeon.Monster = chest.Monster;
                player.Dungeon.Chest = null;
                Console.Instance.Entry("Monster jumped out of the box!");
                player.Investigate();
            }
            else
            {
                player.AddItem(chest.Item);
                UIController.OnPlayerInventoryChange();
                Console.Instance.Entry("You found: " + chest.Item);
            }
            player.Dungeon.Chest = null;
            dynamicControls[3].interactable = false;
        }

        //method for what happens when attack button is pressed
        //player and monster will lose hp depending on how much attack defence is calculated
        public void Attack()
        {
            int playerDamageAmount = (int)(Random.value * (player.Attack - Monster.Defence));
            int monsterDamageAmount = (int)(Random.value * (Monster.Attack - player.Defence));
            Console.Instance.Entry("<color=#59ffa1>You dealt <b>" + playerDamageAmount + "</b> damage!</color>");
            Console.Instance.Entry("<color=#59ffa1>The monster attacked dealing <b>" + monsterDamageAmount + "</b> damage back!</color>");
            player.Attacked(monsterDamageAmount);
            Monster.Attacked(playerDamageAmount);
        }

        //escape method for when escape button is pressed
        //player will be attacked once but monster will be gone
        public void Escape()
        {
            int monsterDamageAmount = (int)(Random.value * (Monster.Attack - (player.Defence * .5f)));
            player.Dungeon.Monster = null;
            UIController.OnMonsterUpdate(null);
            player.Attacked(monsterDamageAmount);
            Console.Instance.Entry("<color=#59ffa1>During the escape the monster dealt <b>" + monsterDamageAmount + "</b> damage!</color>");
            player.Investigate();
        }

        //player will go up one floor level then generate a new roomindex map
        public void ExitFloor()
        {
            StartCoroutine(player.region.GenerateFloor());
            player.Floor += 1;
            Console.Instance.Entry("You found an exit to floor: " + player.Floor);
            player.Investigate();
        }

        //function for looting a monsters items when it dies
        //depending on a percentage chance you will get normal items or special item
        //prints what you find
        public void Pickup()
        {
            if (Random.Range(0, 19) == 0)
            {
                player.AddItem(this.Monster.Inventory[0]);
                player.AddItem(this.Monster.Inventory[1]);
                Console.Instance.Entry(string.Format("<color=#56FFC7FF>You've defeated {0}. Searching the remains, {1} and {2} found!</color>",
                    this.Monster.Description, this.Monster.Inventory[0], this.Monster.Inventory[1]));
            }
            else
            {
                player.AddItem(this.Monster.Inventory[0]);
                Console.Instance.Entry(string.Format("<color=#56FFC7FF>You've defeated {0}. Searching the remains, {1} found!</color>",
                    this.Monster.Description, this.Monster.Inventory[0]));
            }
            player.Dungeon.Monster = null;
            UIController.OnMonsterUpdate(null);
            player.Investigate();
        }
    }
}