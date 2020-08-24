using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile {
    public UnitStats unitStats;
    string playerName;
    int gold;
    int experience;

    public string ReturnPlayerName() {
        return playerName;
    }

    public void SetPlayerName(string name) {
        playerName = name;
    }
    public int ReturnGold() {
        return gold;
    }

    public void SetGold(int amount) {
        gold = amount;
    }
    public int ReturnExperience() {
        return experience;
    }

    public void SetExperience(int amount) {
        experience = amount;
    }
}
