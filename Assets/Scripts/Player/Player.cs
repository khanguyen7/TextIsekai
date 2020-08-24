using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerProfile profile;

    // Start is called before the first frame update
    void Start() {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // UI Methods

    public void IncreaseMoney() {
        profile.SetGold(profile.ReturnGold() + 1);
    }
    
    public void DecreaseMoney() {
        profile.SetGold(profile.ReturnGold() - 1);
    }

    public void IncreaseExperience() {
        profile.SetExperience(profile.ReturnExperience() + 10);
    }

    public void DecreaseExperience() {
        profile.SetExperience(profile.ReturnExperience() + 10);
    }

    public void DecreaseHealth() {
        profile.unitStats.health -= 5;
    }
    public void IncreaseHealth() {
        profile.unitStats.health += 5;
    }
}
