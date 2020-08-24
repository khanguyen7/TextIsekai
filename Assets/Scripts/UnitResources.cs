using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitResources: MonoBehaviour {
    // Variables
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public float currentMana = 100f;
    public float maxMana = 100f;
    public float experience = 0f; //public for now
    //[SerializeField] GameObject deathVFX;

    // Getters
    public float GetHealthValue() {
        return currentHealth;
    }

    public float GetManaValue() {
        return currentMana;
    }
    public float GetExpValue() {
        return experience;
    }
    // Setters
    public void ReduceHealth(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            //TriggerDeathVFX();
            Destroy(gameObject);
        }
    }
    public void IncreaseHealth(float healAmount) {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }

    public bool UseMana(float amount) {
        if (currentMana < amount) { return false; }
        else
        {
            currentMana -= amount;
            return true;
        }
    }
    public void RegenMana(float amount) {
        currentMana += amount;
        if (currentMana > maxMana) {
            currentMana = maxMana;
        }
    }
    public void GainExperience(float amount) {
        experience += amount;
        // TODO: level ups
    }
    /*private void TriggerDeathVFX() {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }*/
}