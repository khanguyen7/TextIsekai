using UnityEngine;
// This SO class is used to create item databases, which hold a list of items and auto sets their ID
[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver {
    // currently only planned on using one database, but we could perhaps create multiple dbs to sort the items out.
    public ItemObject[] ItemObjects;
    // Methods
    [ContextMenu("Update IDs")]
    public void UpdateID() {
        // Sets the IDs of the items in the database
        for (int i = 0; i < ItemObjects.Length; i++) {
            if (ItemObjects[i].data.Id != i) {
                ItemObjects[i].data.Id = i;
            }
        }
    }
    public void OnAfterDeserialize() {
        UpdateID();
    }
    public void OnBeforeSerialize() {
    }
}
