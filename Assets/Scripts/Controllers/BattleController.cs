using System.Collections;
using System.Collections.Generic;
using Battle;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    private BattleManager _battleManager;
    
    private void Start()
    {
        _battleManager = BattleManager.Instance;
        Debug.Log(_battleManager);
        BattleManager.Instance.InstantiateSlots();
        BattleManager.Instance.LoadPartyToBattle();
        PlayerTurn();
    }
    public void PlayerTurn()
    {
        foreach (Character character in _battleManager.charactersParty.characters)
        {
            _battleManager.playerActions++;
        }
        //Disable InBattle Targets
        _battleManager.DisableAllTargets();
        //Activate Characters UI
        foreach (BattleSlot sheet in _battleManager.playerCharSheet)
        {
            _battleManager.EnableCharacterUI(sheet);
        }
    }
    public void EnemyTurn()
    {
        PlayerTurn();
    }
    public void CheckActions()
    {
        _battleManager.playerActions--;
        if (_battleManager.playerActions <= 0)
            EnemyTurn();
    }
   
}
