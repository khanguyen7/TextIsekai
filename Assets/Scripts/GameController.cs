using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    SceneLoader sceneLoader;
    //PlayerPrefsController playerPrefsController;
    public Player player;
    SaveData saveData;
    GameState gameState;
    string currentGameState = "";
    UIController uIController;
    public TextController textController;

    void Start() {
        // Start is called before the first frame update
        //DontDestroyOnLoad(this);
        //sceneLoader = FindObjectOfType<SceneLoader>();
        //playerPrefsController = FindObjectOfType<PlayerPrefsController>();

        /*if (playerPrefsController.GetReturningPlayerVal() == 0) {
            sceneLoader.LoadFirstTimeScene();
        }
        else {
            // load saved game data before loading scene
            sceneLoader.LoadMainGameScene();
        }*/
        uIController = GetComponent<UIController>();
        gameState = new GameState();

        saveData = SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");

        LoadData();
        gameState.SetTownState();
        currentGameState = gameState.GetCurrentState();

        uIController.InitializeUI();
        textController.CreateText("this is a text message");

        textController.CreateText("this is a text message");
        textController.CreateText("this is a text message");
        textController.CreateText("this is a text message");
    }

    private void OnApplicationQuit() {
        SerializationManager.Save("Save", new SaveData(player, gameState));
    }

    private void Update() {

    }

    private void LoadData() {
        player.profile.unitStats.maxHealth = saveData.maxHealth;
        player.profile.unitStats.maxMana = saveData.maxMana;
        player.profile.unitStats.health = saveData.health;
        player.profile.unitStats.mana = saveData.mana;
        player.profile.gold = saveData.gold;
        gameState.currentState = saveData.currentGameState;
    }

    // everytime we change locations and change game state, call method in tabgroups to change default page
    public string GetCurrentGameState() {
        return currentGameState;
    }
}
