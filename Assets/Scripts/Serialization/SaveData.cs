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
    public int experience;
    public string currentGameState;
    public string playerName;
    public List<int> stats;
    public int attackDMG;
    public int magicDMG;
    public int defense;
    public int agility;
    public int strength; // affects attackDMG
    public int intelligence; //affects magicDMG
    public int constitution; //affects health
    public int wisdom; //affects mana
    public int celerity; // affects agility

    public SaveData (Player player, GameState gameState) {
        maxHealth = player.profile.unitStats.maxHealth;
        maxMana = player.profile.unitStats.maxMana;
        health = player.profile.unitStats.health;
        mana = player.profile.unitStats.mana;
        gold = player.profile.ReturnGold();
        experience = player.profile.ReturnExperience();
        // this hurts to look at, need to figure out why the list from before did not work
        attackDMG = player.profile.unitStats.ReturnStat("attackDMG");
        magicDMG = player.profile.unitStats.ReturnStat("magicDMG");
        defense = player.profile.unitStats.ReturnStat("defense");
        agility = player.profile.unitStats.ReturnStat("agility");
        strength = player.profile.unitStats.ReturnStat("strength");
        intelligence = player.profile.unitStats.ReturnStat("intelligence");
        constitution = player.profile.unitStats.ReturnStat("constitution");
        wisdom = player.profile.unitStats.ReturnStat("wisdom");
        celerity = player.profile.unitStats.ReturnStat("celerity");

        currentGameState = gameState.GetCurrentState();
        playerName = player.profile.ReturnPlayerName();

    }
}
