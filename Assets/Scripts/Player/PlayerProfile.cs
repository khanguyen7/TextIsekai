using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile {
    public UnitStats unitStats;
    string playerName;
    public int gold;
    public int experience;

    public string ReturnPlayerName() {
        return playerName;
    }

    public void SetPlayerName(string name) {
        playerName = name;
    }
}
