using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// the data to save
[System.Serializable]
public class SaveData {

    public int health;
    public int mana;
    public int maxHealth;
    public int maxMana;
    public int gold;
    public string currentGameState;
    public string playerName;

    public SaveData (Player player, GameState gameState) {
        maxHealth = player.profile.unitStats.maxHealth;
        maxMana = player.profile.unitStats.maxMana;
        health = player.profile.unitStats.health;
        mana = player.profile.unitStats.mana;
        gold = player.profile.gold;
        currentGameState = gameState.GetCurrentState();
        playerName = player.profile.ReturnPlayerName();

    }
}
