using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
// This serialization manager is what actually saves and loads the SaveData into a file.
public class SerializationManager : MonoBehaviour {
    public static bool Save(string saveName, SaveData saveData) {
        // Serializes the given saveData to a file of name saveName in a saves folder
        if (!Directory.Exists(Application.persistentDataPath + "/saves")) {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";
        FileStream file = new FileStream(path, FileMode.Create);
        formatter.Serialize(file, saveData);
        file.Close();

        return true; // can use this returned bool for checks in the future if needed
    }
    public static SaveData Load(string path) {
        // Unserializes the data in the given path to a file if it exists
        if (!File.Exists(path)) {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = new FileStream(path, FileMode.Open);
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

    public static BinaryFormatter GetBinaryFormatter() {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }
}
