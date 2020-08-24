using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// The Player class houses all the components of the player, as well as methods to manipulate data.
public class Player : MonoBehaviour {

    public PlayerProfile profile;
    public UnitStats stats;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
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
        stats.health -= 5;
    }
    public void IncreaseHealth() {
        stats.health += 5;
    }
}
