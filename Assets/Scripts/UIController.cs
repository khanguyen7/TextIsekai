﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Player player;
    public Text moneyDisplay;
    public ProgressBar healthBar;
    public ProgressBar manaBar;

    // Start is called before the first frame update
    void Start() {
        moneyDisplay.text = player.profile.gold.ToString();
        healthBar.SetMax(player.profile.unitStats.maxHealth);
        manaBar.SetMax(player.profile.unitStats.maxMana);
    }

    // Update is called once per frame
    void Update() {
        moneyDisplay.text = player.profile.gold.ToString();
        healthBar.SetCurrent(player.profile.unitStats.health);
        manaBar.SetCurrent(player.profile.unitStats.mana);
    }
}