using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit Stats Setting")]
public class UnitStats : ScriptableObject {
    // This scriptable object contains all of the stats every unit in the game will have
    
    // Basic stats
    public int health;
    public int mana;
    public int maxHealth;
    public int maxMana;
    public int experience;
    public int attackDMG;
    public int magicDMG;
    public int physicalDefense;
    public int magicDefense;
    public int agility;
    // Not Basic
    public int strength; // affects attackDMG
    public int intelligence; //affects magicDMG
    public int constitution; //affects health
    public int wisdom; //affects mana
    public int wits; // affects mana costs
    public int celerity; // affects agility

    public IList ReturnStatNames() {
        List<string> statNames = new List<string> {
            "attackDMG",
            "magicDMG",
            "physicalDefense",
            "magicDefense",
            "agility",
            "strength",
            "intelligence",
            "constitution",
            "wisdom",
            "wits",
            "celerity"
        };
        return statNames;
    }
    public int ReturnStat(string statName) {
        // has to be a better way to do this
        if (statName == "attackDMG") {
            return attackDMG;
        } else if (statName == "magicDMG") {
            return magicDMG;
        } else if (statName == "PhysicalDefense") {
            return physicalDefense;
        } else if (statName == "magicDefense") {
            return magicDefense;
        } else if (statName == "agility") {
            return agility;
        } else if (statName == "strength") {
            return strength;
        } else if (statName == "intelligence") {
            return intelligence;
        } else if (statName == "constitution") {
            return constitution;
        } else if (statName == "wisdom") {
            return wisdom;
        } else if (statName == "wits") {
            return wits;
        } else {
            return celerity;
        }
    }
    public void SetStat(string statName, int value) {
        // Sets the value of a stat
        if (statName == "attackDMG") {
            attackDMG = value;
        } else if (statName == "magicDMG") {
            magicDMG = value;
        } else if (statName == "physicalDefense") {
            physicalDefense = value;
        } else if (statName == "magicDefense") {
            magicDefense = value;
        } else if (statName == "agility") {
            agility = value;
        } else if (statName == "strength") {
            strength = value;
        } else if (statName == "intelligence") {
            intelligence = value;
        } else if (statName == "constitution") {
            constitution = value;
        } else if (statName == "wisdom") {
            wisdom = value;
        } else if (statName == "wits") {
            wits = value;
        } else {
            celerity = value;
        }
    }
    public void InitializeStat(int value, int index) {
        // currently not used, forgot what I was gonna use this for
        if (index == 0) {
            attackDMG = value;
        } else if (index == 1) {
            magicDMG = value;
        } else if (index == 2) {
            physicalDefense = value;
        } else if (index == 3) {
            magicDefense = value;
        } else if (index == 4) {
            agility = value;
        } else if (index == 5) {
            strength = value;
        } else if (index == 6) {
            intelligence = value;
        } else if (index == 7) {
            constitution = value;
        } else if (index == 8) {
            wisdom = value;
        } else if (index == 9) {
            wits = value;
        } else {
            celerity = value;
        }
    }
}
