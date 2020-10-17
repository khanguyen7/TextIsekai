using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// The Player class houses all the components of the player, as well as methods to manipulate data.
public class Player : MonoBehaviour {

    public PlayerProfile profile;
    public UnitStats stats;

    public InventoryObject inventory;
    public InventoryObject equipment;

    public Attribute[] attributes;

    // Start is called before the first frame update
    private void Start() {
        for (int i = 0; i < attributes.Length; i++) {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++) {
            equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }

        attributes[0].value.BaseValue = 5;
    }

    public void OnBeforeSlotUpdate(InventorySlot _slot) {
        if (_slot.ItemObject == null) {
            return;
        }
        switch (_slot.GetParent().inventory.type) {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Removed ", _slot.ItemObject, " on ", _slot.GetParent().inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItemTypes)));
                // Remove the stats from item to the player's attributes
                for (int i = 0; i < _slot.item.attributesOnItem.Length; i++) {
                    for (int j = 0; j < attributes.Length; j++) {
                        if (attributes[j].type == _slot.item.attributesOnItem[i].attribute) {
                            attributes[j].value.RemoveModifier(_slot.item.attributesOnItem[i]);
                        }
                    }
                }
                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
        }
    }
    public void OnAfterSlotUpdate(InventorySlot _slot) {
        if (_slot.ItemObject == null) {
            return;
        }
        switch (_slot.GetParent().inventory.type) {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Added ", _slot.ItemObject, " on ", _slot.GetParent().inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItemTypes)));
                // Add the stats from item to the player's attributes
                for (int i = 0; i < _slot.item.attributesOnItem.Length; i++) {
                    for (int j = 0; j < attributes.Length; j++) {
                        if (attributes[j].type == _slot.item.attributesOnItem[i].attribute) {
                            attributes[j].value.AddModifier(_slot.item.attributesOnItem[i]);
                        }
                    }
                }
                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update() {
        
        // For testing
        if (Input.GetKeyDown(KeyCode.Keypad0)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[0]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[1]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[2]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[3]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[4]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[5]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[6]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[7]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[8]), 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad9)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[9]), 1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadDivide)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[10]), 1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[11]), 1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[12]), 1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[13]), 1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[14]), 1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPeriod)) {
            inventory.AddItem(new Item(inventory.database.ItemObjects[15]), 1);
        }
    }

    public void AttributeModified(Attribute attribute) {
        Debug.Log(string.Concat(attribute.type, " was updated! value is now ", attribute.value.ModifiedValue));
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

[System.Serializable]
public class Attribute {
    [NonSerialized]
    public Player parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(Player _parent) {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);   
    }
    public void AttributeModified() {
        parent.AttributeModified(this);
    }
}
