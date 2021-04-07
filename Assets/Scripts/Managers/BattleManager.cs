using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BattleManager : SingletonSystem
    {
        /////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Singleton of BattleManager
        /// </summary>
        public static BattleManager Instance;
        protected override void BuildSingleton()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        /////////////////////////////////////////////////////////////////////////////
        private void Awake()
        {
            BuildSingleton();
        }

        #region Public Variables
        
        //Teams Party Variables
        [Header("Teams Party")] 
        public CharactersParty charactersParty;
        public CharactersParty enemyParty;

        //InBattle Prefabs
        [Header("InBattle Target Prefabs")] 
        public GameObject allySlotPrefab;
        public GameObject enemySlotPrefab;

        //GameObject parent of Prefabs
        [Header("Characters Spawn Parent")] 
        public GameObject alliesParent;
        public GameObject enemiesParent;

        //Characters Spawnpoints
        [Header("Spawnpoints")] 
        public Transform[] allySpawnpoints;
        public Transform[] enemySpawnpoints;

        //UI SLOTS
        [Header("PlayerUI")] 
        public List<BattleSlot> playerCharSheet = new List<BattleSlot>();

        //List to add Party Characters to Grid
        [HideInInspector] public List<Button> battleCharacters = new List<Button>();
        [HideInInspector] public List<Button> battleEnemies = new List<Button>();
        //Actions Player Have x Turn
        public int playerActions;
        [HideInInspector]public Button[] buttonComponents;

        #endregion

        #region Private Variables
        
        
        #endregion
        public void LoadPartyToBattle()
        {
            for (int i = 0; i < charactersParty.characters.Count; i++)
            {
                playerCharSheet[i].gameObject.SetActive(true);
                playerCharSheet[i].ch = charactersParty.characters[i];
                playerCharSheet[i].LoadSlot();
            }
        }
        public void InstantiateSlots()
        {
            for (int i = 0; i < charactersParty.characters.Count; i++)
            {
                GameObject go = Instantiate(allySlotPrefab, allySpawnpoints[i]);
                go.transform.SetParent(alliesParent.transform);
                var battle = go.GetComponent<InBattle>();
                battle.slot = i;
                //go.GetComponent<Image>().sprite = battle.party.characters[i].charSprite;
                var character = go.GetComponent<Button>();
                character.onClick.AddListener(DisableAllTargets);
                character.onClick.AddListener(delegate { go.GetComponent<InBattle>().SelectedTarget(); });
                character.onClick.AddListener(CheckActions);
                battleCharacters.Add(character);
            }
            for (int i = 0; i < enemyParty.characters.Count; i++)
            {
                GameObject go = Instantiate(enemySlotPrefab, enemySpawnpoints[i]);
                go.transform.SetParent(enemiesParent.transform);
                go.GetComponent<InBattle>().slot = i;
                var character = go.GetComponent<Button>();
                character.onClick.AddListener(DisableAllTargets);
                character.onClick.AddListener(delegate { go.GetComponent<InBattle>().SelectedTarget(); });
                character.onClick.AddListener(CheckActions);
                battleEnemies.Add(character);
            }
        }
        /// <summary>
        /// Disable all characters in battle
        /// </summary>
        /// <param name="Slots"> List of Gameobjects to be deactivated</param>
        public void DisableAllTargets()
        {
            foreach (Button btn in battleCharacters)
            {
                btn.interactable = false;
            }
            foreach (Button btn in battleEnemies)
            {
                btn.interactable = false;
            }
        }
        /// <summary>
        /// Check in witch team the spell can be used
        /// </summary>
        /// <param name="battleSlot"></param>
        public void CheckTeamInteract(BattleSlot battleSlot)
        {
            if (battleSlot.ch.skills[BattleSlot.lastSkillUsed].team == SkillObject.Team.Allies)
            {
                foreach (Button btn in battleCharacters) { btn.interactable = true; }
                foreach (Button btn in battleEnemies) { btn.interactable = false; }
            }
            else if (battleSlot.ch.skills[BattleSlot.lastSkillUsed].team == SkillObject.Team.Enemies)
            {
                foreach (Button btn in battleCharacters) { btn.interactable = false; }
                foreach (Button btn in battleEnemies) { btn.interactable = true; }
            }
        }
        public void CheckActions()
        {
            playerActions--;
            if (playerActions <= 0)
                GetComponent<BattleController>().EnemyTurn();
        }
        //UI INTERACTIONS FUNCTIONS//
        public void EnableCharacterUI(BattleSlot UICharacter)
        {
            if (UICharacter.ch != null)
            {
                var component = UICharacter.GetComponentsInChildren<Button>();
                foreach (Button button in component)
                {
                    button.interactable = !button.interactable;
                }
            }
        }
        public void InteractableCharacter(BattleSlot UICharacter)
        {
            foreach (BattleSlot slot in playerCharSheet)
            {
                if (UICharacter != slot && slot.used == false)
                    slot.SwapButtons(true);
                else
                    slot.SwapButtons(false);
            }
        }
        /*public void Retreat()
        {
            if (buttonComponents != null)
            {
                foreach (Button button in buttonComponents)
                {
                    button.interactable = true;
                }
                DisableAllTargets();
                buttonComponents = null;
            }else
            {
                Debug.Log("No hiciste click en ninguno");
            }
        }*/
    }
}
