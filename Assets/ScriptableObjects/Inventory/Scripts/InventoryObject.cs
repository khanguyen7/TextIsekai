using UnityEngine;

public enum InterfaceType {
    Inventory,
    Equipment,
    Chest
}

// This SO class is used to create inventories that can be assigned to other scripts.
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject {
    public ItemDatabaseObject database; // The database of items being referenced.
    public InterfaceType type;
    public Inventory Container; // The actual Inventory that will house items.
    public InventorySlot[] GetSlots { get { return Container.Slots; } }
    public int EmptySlotCount {
        // Returns how many empty slots there are in the inventory
        get {
            int counter = 0;
            for (int i = 0; i < GetSlots.Length; i++) {
                if (GetSlots[i].item.Id <= -1)
                    counter++;
            }
            return counter;
        }
    }
    // Methods
    public bool AddItem(Item _item, int _amount) {
        // Adds an item to an inventory if there is space
        if (EmptySlotCount <= 0) {
            return false;
        }
        InventorySlot slot = FindItemOnInventory(_item); // Check to see if the item is already in inventory, if so stack it.
        if (!database.ItemObjects[_item.Id].stackable || slot == null) { // If the item is not stackable or item is not already in inventory
            SetEmptySlot(_item, _amount);
            return true;
        }
        slot.AddAmount(_amount);
        return true;
    }
    private InventorySlot FindItemOnInventory(Item _item) {
        // Checks to see if item is already in the inventory and returns the slot if it is.
        for (int i = 0; i < GetSlots.Length; i++) {
            if (GetSlots[i].item.Id == _item.Id) {
                return GetSlots[i];
            }
        }
        return null;
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount) {
        // Adds the item to the first empty slot found
        for (int i = 0; i < GetSlots.Length; i++) {
            if (GetSlots[i].item.Id <= -1) {
                GetSlots[i].UpdateSlot(_item, _amount);
                return GetSlots[i];
            }
        }
        // set up functionality for adding to full inventory
        return null;
    }
    public void SwapItems(InventorySlot item1, InventorySlot item2) {
        // Swaps items in inventory slots
        if (item2.CanPlaceInSlot(item1.ItemObject) && item1.CanPlaceInSlot(item2.ItemObject)) {
            InventorySlot temp = new InventorySlot(item2.item, item2.amount);
            item2.UpdateSlot(item1.item, item1.amount);
            item1.UpdateSlot(temp.item, temp.amount);
        }
    }
    // Unity editor specific
    [ContextMenu("Clear")]
    public void ClearInventory() {
        Container.Clear();
    }
}
