using UnityEngine;
using System.IO;

public static class SaveSystem {
    static string path = Application.persistentDataPath + "/save.json";

    public static void Save(GameData data) {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public static GameData Load() {
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<GameData>(json);
        }
        return new GameData(); // default baru
    }
}
