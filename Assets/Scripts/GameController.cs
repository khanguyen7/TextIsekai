using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    SceneLoader sceneLoader;
    //PlayerPrefsController playerPrefsController;
    public Player player;
    SaveData saveData;

    // Start is called before the first frame update
    void Start() {
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
        saveData = SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");

        player.profile.gold = saveData.gold;
    }

    private void OnApplicationQuit() {
        SerializationManager.Save("Save", new SaveData(player));
    }

    private void Update() {

    }
}
