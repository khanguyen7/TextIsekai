using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit Stats Setting")]
public class UnitStats : ScriptableObject {
    // This scriptable object contains all of the stats every unit in the game will have
    
    // Basic
    public int health;
    public int mana;
    public int maxHealth;
    public int maxMana;
    public int experience;
    public int attackDMG;
    public int defense;
    public int agility;
    public int spellCastMod;


    // Not Basic
    public int strength;
    public int intelligence;
    public int constitution;
    public int wisdom;
    public int wits;
}
