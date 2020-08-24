using UnityEngine;
// This class handles the use of the playerprefs to save non-important information.
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

    public void SetNewPlayerVal() {
        PlayerPrefs.SetInt(FIRST_TIME_KEY, 0);
        // for testing purposes
    }

    public int GetReturningPlayerVal() {
        //Debug.Log(PlayerPrefs.GetInt(FIRST_TIME_KEY));
        return PlayerPrefs.GetInt(FIRST_TIME_KEY);
    }
}
