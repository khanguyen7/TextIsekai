using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {

    const string FIRST_TIME_KEY = "new player";
    void Start() {
        if (PlayerPrefs.GetInt(FIRST_TIME_KEY, -1) == -1) {
            PlayerPrefs.SetInt(FIRST_TIME_KEY, 0);
        }
    }

    public void SetReturningPlayerVal() {
        PlayerPrefs.SetInt(FIRST_TIME_KEY, 1);
    }

    public int GetReturningPlayerVal() {
        Debug.Log(PlayerPrefs.GetInt(FIRST_TIME_KEY));
        return PlayerPrefs.GetInt(FIRST_TIME_KEY);
    }
}
