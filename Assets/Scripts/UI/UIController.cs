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
    public GameObject statsContainer;
    public Text textObjectPrefab;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        moneyDisplay.text = player.profile.ReturnGold().ToString();
        healthBar.SetCurrent(player.profile.unitStats.health);
        manaBar.SetCurrent(player.profile.unitStats.mana);
    }

    public void InitializeUI() {
        playerNameDisplay.text = player.profile.ReturnPlayerName();
        moneyDisplay.text = player.profile.ReturnGold().ToString();
        healthBar.SetMax(player.profile.unitStats.maxHealth);
        manaBar.SetMax(player.profile.unitStats.maxMana);
        tabGroup.InitializeDefaultPage();
        SetupStatsDisplay();
    }

    private void SetupStatsDisplay() {

        foreach (string stat in player.profile.unitStats.ReturnStatNames()) {
            Text statsText = Instantiate(textObjectPrefab, statsContainer.transform);
            statsText.text = stat + " = " + player.profile.unitStats.ReturnStat(stat).ToString();
            statsText.transform.localScale = new Vector3(1, 1, 1);
            statsText.fontSize = 40;
        }
    }

    public void UpdateSingleStatDisplay(string statName) {
        if (statName == "attackDMG") {
            statsContainer.transform.GetChild(0).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        } else if (statName == "magicDMG") {
            statsContainer.transform.GetChild(1).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        } else if (statName == "defense") {
            statsContainer.transform.GetChild(2).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        } else if (statName == "agility") {
            statsContainer.transform.GetChild(3).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        } else if (statName == "strength") {
            statsContainer.transform.GetChild(4).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        } else if (statName == "intelligence") {
            statsContainer.transform.GetChild(5).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        } else if (statName == "constitution") {
            statsContainer.transform.GetChild(6).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        } else if (statName == "wisdom") {
            statsContainer.transform.GetChild(7).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        } else {
            statsContainer.transform.GetChild(8).GetComponent<Text>().text = statName + " = " + player.profile.unitStats.ReturnStat(statName).ToString();
        }
    }

}
