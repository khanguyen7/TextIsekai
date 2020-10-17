using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This class controls the flow of the game, as well as loading and saving data during startup and quitting.
public class GameController : MonoBehaviour {
    // Other Components
    PlayerPrefsController playerPrefsController;
    public Player player;
    public UIController uIController;
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

        //playerPrefsController.SetNewPlayerVal(); // for testing in editor

        returningPlayerVal = playerPrefsController.GetReturningPlayerVal();

        if (returningPlayerVal == 0) {
            Debug.Log("New player setup");
            NewPlayerSetup();
        } else {
            // load saved game data before loading scene
            Debug.Log("returning player setup");
            Setup();

            //test updating stats
            player.stats.SetStat("attackDMG", 10);
            uIController.UpdateSingleStatDisplay("attackDMG");
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    private void OnApplicationQuit() {
        SerializationManager.Save("Save", new SaveData(player, gameState), new InventorySaveData(player));
        // clear inventories to make sure nothing weird happens when we load the saved inventories when reopening the game
        player.inventory.Container.Clear();
        player.equipment.Container.Clear();
    }

    private void Update() {

    }

    private void Setup() {
        gameState = new GameState();
        // THE SAVE PATHS ARE IMPORTANT TO GET RIGHT DONT FUCK IT UP AGAIN LOL
        // also uh probably move this to its own method
        saveData = SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");
        var playerInven = player.inventory.Container.Slots;
        var tempContainer = SerializationManager.LoadInventory(Application.persistentDataPath + "/saves/SaveInventory.inventory");
        for (int i = 0; i < playerInven.Length; i++) {
            //Debug.Log("updating inventory slot i = " + i);
            playerInven[i].UpdateSlot(tempContainer.Slots[i].item, tempContainer.Slots[i].amount);
        }
        var playerEquip = player.equipment.Container.Slots;
        tempContainer = SerializationManager.LoadInventory(Application.persistentDataPath + "/saves/SaveEquipment.equipment");
        for (int i = 0; i < playerEquip.Length; i++) {
            playerEquip[i].UpdateSlot(tempContainer.Slots[i].item, tempContainer.Slots[i].amount);
        }

        LoadData();
        //LoadDefaultData();
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
        player.stats.SetStat("physicalDefense", saveData.physicalDefense);
        player.stats.SetStat("magicDefense", saveData.magicDefense);
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