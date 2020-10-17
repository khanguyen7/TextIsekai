using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
// This serialization manager is what actually saves and loads the SaveData into a file.
public class SerializationManager : MonoBehaviour {
    public static bool Save(string saveName, SaveData saveData, InventorySaveData inventorySaveData) {
        string pathStart = string.Concat(Application.persistentDataPath, "/saves/");
        // Serializes the given saveData to a file of name saveName in a saves folder
        if (!Directory.Exists(pathStart)) {
            Directory.CreateDirectory(pathStart);
        }
        // Save the player data
        BinaryFormatter formatter = GetBinaryFormatter();
        string path = string.Concat(pathStart, saveName, ".save");
        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
        formatter.Serialize(file, saveData);
        file.Close();
        // save player inventory
        string inventoryPath = string.Concat(pathStart, saveName, "Inventory", ".inventory");
        FileStream inventoryFile = new FileStream(inventoryPath, FileMode.Create, FileAccess.Write);
        formatter.Serialize(inventoryFile, inventorySaveData.playerInventory);
        inventoryFile.Close();
        // save player equipment (its technically a 2nd inventory)
        string equipmentPath = string.Concat(pathStart, saveName, "Equipment", ".equipment");
        FileStream equipmentFile = new FileStream(equipmentPath, FileMode.Create, FileAccess.Write);
        formatter.Serialize(equipmentFile, inventorySaveData.playerEquipment);
        equipmentFile.Close();

        return true; // can use this returned bool for checks in the future if needed
    }
    public static SaveData Load(string path) {
        // Unserializes the data in the given path to a file if it exists
        if (!File.Exists(path)) {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
        try {
            SaveData save = formatter.Deserialize(file) as SaveData;
            file.Close();
            return save;
        } catch {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }
    public static Inventory LoadInventory(string path) {
        // Unserializes the data in the given path to a file if it exists
        // specifically for inventories
        if (!File.Exists(path)) {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
        try {
            Inventory inventory = formatter.Deserialize(file) as Inventory;
            file.Close();
            return inventory;
        } catch {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }
    public static BinaryFormatter GetBinaryFormatter() {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }
}
