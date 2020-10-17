// This class is the "real" inventory class which contains a list of inventory slots
[System.Serializable]
public class Inventory {
    public InventorySlot[] Slots = new InventorySlot[30];
    // Methods
    public void Clear() {
        // Clears the inventory
        for (int i = 0; i < Slots.Length; i++) {
            Slots[i].RemoveItem();
        }
    }
}
