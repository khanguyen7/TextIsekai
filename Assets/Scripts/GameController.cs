using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    //SceneLoader sceneLoader;
    PlayerPrefsController playerPrefsController;
    int returningPlayerVal;

    public Player player;
    SaveData saveData;
    GameState gameState;
    string currentGameState = "";
    UIController uIController;
    public TextController textController;

    public Canvas newGameCanvasPrefab;
    Canvas newGameCanvas;

    void Start() {
        // Start is called before the first frame update

        // if new player then we temporarily create new canvas that holds the player setup stuff
        // then it is destroyed after and the player will see the main UI

        playerPrefsController = GetComponent<PlayerPrefsController>();

        //playerPrefsController.SetNewPlayerVal(); // for testing

        returningPlayerVal = playerPrefsController.GetReturningPlayerVal();

        if (returningPlayerVal == 0) {
            Debug.Log("New player setup");
            NewPlayerSetup();
        } else {
            // load saved game data before loading scene
            Debug.Log("returning player setup");
            Setup();
        }
    }

    private void OnApplicationQuit() {
        SerializationManager.Save("Save", new SaveData(player, gameState));
    }

    private void Update() {

    }

    private void Setup() {
        gameState = new GameState();

        saveData = SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");

        LoadData();
        //LoadDefaultData();

        uIController = GetComponent<UIController>();
        textController = FindObjectOfType<TextController>();

        gameState.SetTownState(); // for testing
        currentGameState = gameState.GetCurrentState();

        uIController.InitializeUI();
        textController.CreateText("this is a text message");
    }

    private void NewPlayerSetup() {

        newGameCanvas = Instantiate(newGameCanvasPrefab);
        playerPrefsController.SetReturningPlayerVal();

        InputField inputField = newGameCanvas.GetComponentInChildren<InputField>();

        inputField.onEndEdit.AddListener(delegate{ validateInput(inputField); });

    }

    void validateInput(InputField inputField) {
        player.profile.SetPlayerName(inputField.text);
        Debug.Log(player.profile.ReturnPlayerName());
        RemoveNewPlayerCanvas();
        gameState = new GameState();

        uIController = GetComponent<UIController>();
        textController = FindObjectOfType<TextController>();

        gameState.SetTownState();
        currentGameState = gameState.GetCurrentState();

        uIController.InitializeUI();
        textController.CreateText("this is a text message");
    }
    private void RemoveNewPlayerCanvas() {
        Destroy(newGameCanvas.gameObject);
    }

    private void LoadData() {
        player.profile.unitStats.maxHealth = saveData.maxHealth;
        player.profile.unitStats.maxMana = saveData.maxMana;
        player.profile.unitStats.health = saveData.health;
        player.profile.unitStats.mana = saveData.mana;
        player.profile.gold = saveData.gold;
        gameState.currentState = saveData.currentGameState;
        player.profile.SetPlayerName(saveData.playerName);
    }

    private void LoadDefaultData() {
        // for testing and resetting purposes
        player.profile.unitStats.maxHealth = saveData.maxHealth;
        player.profile.unitStats.maxMana = saveData.maxMana;
        player.profile.unitStats.health = saveData.maxHealth;
        player.profile.unitStats.mana = saveData.maxMana;
        player.profile.gold = 0;
    }

    // everytime we change locations and change game state, call method in tabgroups to change default page
    public string GetCurrentGameState() {
        return currentGameState;
    }
}
