// This class contains setters and a getter for the current game state
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