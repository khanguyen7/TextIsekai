using System;
using UnityEngine;
// This class defines an InventorySlot Object. Inventory slots contain an item and an amount of that item.
[System.Serializable]
public class InventorySlot {
    public ItemType[] AllowedItemTypes = new ItemType[0];
    public Item item;
    public int amount;
    [NonSerialized]
    private UserInterface parent; // The inventory UI that this slot is displayed on
    public ItemObject ItemObject {
        // If there is an item on this slot, we retrieve info about the item from the database
        get {
            if (item.Id >= 0) {
                return parent.inventory.database.ItemObjects[item.Id];
            }
            return null;
        }
    }
    [NonSerialized]
    public GameObject slotDisplay; // Reference to the actual gameobject in the scene for this slot
    [NonSerialized]
    public SlotUpdated OnBeforeUpdate;
    [NonSerialized]
    public SlotUpdated OnAfterUpdate;
    // Constructors
    public InventorySlot() {
        // Default constructor
        UpdateSlot(new Item(), 0);
    }
    public InventorySlot(Item _item, int _amount) {
        // Secondary constructor
        UpdateSlot(_item, _amount);
    }
    // Methods
    public void UpdateSlot(Item _item, int _amount) {
        // Updates slot info
        if (OnBeforeUpdate != null) {
            OnBeforeUpdate.Invoke(this);
        }
        item = _item;
        amount = _amount;
        if (OnAfterUpdate != null) {
            OnAfterUpdate.Invoke(this);
        }
    }
    public void RemoveItem() {
        // 'removes' item from slot
        UpdateSlot(new Item(), 0);
    }
    public void AddAmount(int value) {
        // Increases amount of item in slot
        UpdateSlot(item, amount += value);
    }
    public bool CanPlaceInSlot(ItemObject _itemObject) {
        // Checks to see if an item can be placed in this slot
        if (AllowedItemTypes.Length <= 0 || _itemObject == null || _itemObject.data.Id < 0) { return true; }
        for (int i = 0; i < AllowedItemTypes.Length; i++) {
            if (_itemObject.type == AllowedItemTypes[i]) { return true; }
        }
        return false;
    }
    public void SetParent(UserInterface parentUI) {
        // Sets a reference to the UI this slot is a child to
        parent = parentUI;
    }
    public UserInterface GetParent() {
        // Returns parent UI this slot is a child to
        return parent;
    }
}

public delegate void SlotUpdated(InventorySlot _slot);
