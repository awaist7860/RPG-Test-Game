using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles interaction with enemies
[RequireComponent(typeof(CharacterStats))]
public class Enemy : interactable
{

    PlayerManager playerManager;
    CharacterStats myStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        //Attack the enemy
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();

        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }
}
