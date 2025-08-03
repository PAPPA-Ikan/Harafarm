using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    public Text inventoryText;

    void Update() {
        var data = GameManager.instance.gameData;
        inventoryText.text = "Inventory:\n";
        foreach (var item in data.inventory) {
            inventoryText.text += "- " + item + "\n";
        }

        inventoryText.text += "\nPanen:\n";
        foreach (var entry in data.harvested) {
            inventoryText.text += entry.Key + ": " + entry.Value + "\n";
        }

        inventoryText.text += "\nCoins: " + data.coins;
    }
}
