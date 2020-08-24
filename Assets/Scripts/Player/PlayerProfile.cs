using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This class contains all the information about the profile of a player
// Future things to add: Guild ranks, achievements, other statistics.
[System.Serializable]
public class PlayerProfile {
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
