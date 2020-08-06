using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerProfile profile;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // UI Methods

    public void IncreaseMoney() {
        profile.gold += 1;
    }
    
    public void DecreaseMoney() {
        profile.gold -= 1;
    }

    public void DecreaseHealth() {
        profile.unitStats.health -= 5;
    }
    public void IncreaseHealth() {
        profile.unitStats.health += 5;
    }
}
