using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A central script from which any and all UI-related methods and called

public class UIController : MonoBehaviour {
    public Player player;
    public Text playerNameDisplay;
    public Text moneyDisplay;
    public ProgressBar healthBar;
    public ProgressBar manaBar;
    public TabGroup tabGroup;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        moneyDisplay.text = player.profile.gold.ToString();
        healthBar.SetCurrent(player.profile.unitStats.health);
        manaBar.SetCurrent(player.profile.unitStats.mana);
    }

    public void InitializeUI() {
        playerNameDisplay.text = player.profile.ReturnPlayerName();
        moneyDisplay.text = player.profile.gold.ToString();
        healthBar.SetMax(player.profile.unitStats.maxHealth);
        manaBar.SetMax(player.profile.unitStats.maxMana);
        tabGroup.InitializeDefaultPage();
    }

}
