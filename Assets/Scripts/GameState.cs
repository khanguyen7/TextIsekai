using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState {

    string[] listOfStates = {"town", "battle", "gather"};
    public string currentState;

    public void SetTownState() {
        currentState = listOfStates[0];
    }
    public void SetBattleState() {
        currentState = listOfStates[1];
    }
    public void SetGatherState() {
        currentState = listOfStates[2];
    }

    public string GetCurrentState() {
        return currentState;
    }
}
