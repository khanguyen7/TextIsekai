using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This class controls the flow of the game, as well as loading and saving data during startup and quitting.
public class GameController : MonoBehaviour {
    // Other Components
    PlayerPrefsController playerPrefsController;
    public Player player;
    UIController uIController;
    public TextController textController; // if we are using sprites then we will get rid of all the Text stuff.
    // Variables
    int returningPlayerVal;
    string currentGameState = "";
    Canvas newGameCanvas;
    SaveData saveData;
    GameState gameState;
    // Prefabs
    public Canvas newGameCanvasPrefab;

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

            //test updating stats
            player.stats.SetStat("attackDMG", 1);
            uIController.UpdateSingleStatDisplay("attackDMG");
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
        // Setup that only happens when you open the game for the first time
        newGameCanvas = Instantiate(newGameCanvasPrefab); // Creates new canvas that holds new player setup UI
        playerPrefsController.SetReturningPlayerVal();

        InputField inputField = newGameCanvas.GetComponentInChildren<InputField>();
        // Add new listener to see when the player is done typing their name.
        inputField.onEndEdit.AddListener(delegate{ validateInput(inputField); });
    }
    void validateInput(InputField inputField) {
        // do some input validation here


        // finish game setup ******move this to it's own method?? or rename method
        player.profile.SetPlayerName(inputField.text);
        Debug.Log(player.profile.ReturnPlayerName());
        Destroy(newGameCanvas.gameObject);
        gameState = new GameState();

        uIController = GetComponent<UIController>();
        textController = FindObjectOfType<TextController>();

        gameState.SetTownState();
        currentGameState = gameState.GetCurrentState();

        uIController.InitializeUI();
        textController.CreateText("this is a text message");
    }
    private void LoadData() {
        player.stats.maxHealth = saveData.maxHealth;
        player.stats.maxMana = saveData.maxMana;
        player.stats.health = saveData.health;
        player.stats.mana = saveData.mana;
        player.stats.SetStat("attackDMG", saveData.attackDMG);
        player.stats.SetStat("magicDMG", saveData.magicDMG);
        player.stats.SetStat("defense", saveData.defense);
        player.stats.SetStat("agility", saveData.agility);
        player.stats.SetStat("strength", saveData.strength);
        player.stats.SetStat("intelligence", saveData.intelligence);
        player.stats.SetStat("constitution", saveData.constitution);
        player.stats.SetStat("wisdom", saveData.wisdom);
        player.stats.SetStat("celerity", saveData.celerity);
        
        player.profile = saveData.profile;
        gameState.currentState = saveData.currentGameState;
    }

    private void LoadDefaultData() {
        // for testing and resetting purposes
        player.stats.maxHealth = saveData.maxHealth;
        player.stats.maxMana = saveData.maxMana;
        player.stats.health = saveData.maxHealth;
        player.stats.mana = saveData.maxMana;
        player.profile.SetGold(0);
    }

    // everytime we change locations and change game state, call method in tabgroups to change default page
    public string GetCurrentGameState() {
        return currentGameState;
    }
}