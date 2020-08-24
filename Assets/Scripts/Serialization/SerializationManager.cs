using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager : MonoBehaviour {
    public static bool Save(string saveName, SaveData saveData) {
        BinaryFormatter formatter = GetBinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/saves")) {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        FileStream file = new FileStream(path, FileMode.Create);
        formatter.Serialize(file, saveData);
        file.Close();

        return true;
    }
    public static SaveData Load(string path) {
        if (!File.Exists(path)) {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = new FileStream(path, FileMode.Open);
        try {
            SaveData save = formatter.Deserialize(file) as SaveData;
            file.Close();
            return save;
        }
        catch {
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
