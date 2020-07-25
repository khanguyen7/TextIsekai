using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour {
    GameObject playerObject;
    float maxHealth;
    float maxMana;
    Slider healthSlider;
    Slider manaSlider;

    // Start is called before the first frame update
    void Start() {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        maxHealth = playerObject.GetComponent<UnitResources>().maxHealth;
        maxMana = playerObject.GetComponent<UnitResources>().maxMana;
        healthSlider = gameObject.transform.Find("Health").GetComponent<Slider>();
        manaSlider = gameObject.transform.Find("Mana").GetComponent<Slider>();        
    }

    // Update is called once per frame
    void Update() {
        float currentHealth = playerObject.GetComponent<UnitResources>().GetHealthValue();
        float currentMana = playerObject.GetComponent<UnitResources>().GetManaValue();

        healthSlider.value = currentHealth / maxHealth;
        manaSlider.value = currentMana / maxMana;
    }

    public void updateMaxHealthVal(float newVal) {
        maxHealth = newVal;
    }
    public void updateMaxManaVal(float newVal) {
        maxMana = newVal;
    }
}
