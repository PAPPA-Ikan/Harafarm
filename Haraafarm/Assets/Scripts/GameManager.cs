using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameData gameData;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gameData = new GameData();
        } else {
            Destroy(gameObject);
        }
    }

    public void SaveGame() {
        SaveSystem.Save(gameData);
    }
}
