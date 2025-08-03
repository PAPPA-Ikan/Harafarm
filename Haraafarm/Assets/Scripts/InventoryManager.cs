using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    public Text inventoryText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Hindari duplikasi singleton
        }
    }

    public void TambahHasilPanen(string namaItem)
    {
        if (string.IsNullOrEmpty(namaItem))
        {
            Debug.LogWarning("Nama item kosong atau null saat ingin ditambah ke inventory.");
            return;
        }

        if (inventory.ContainsKey(namaItem))
        {
            inventory[namaItem]++;
        }
        else
        {
            inventory[namaItem] = 1;
        }

        Debug.Log($"Item '{namaItem}' ditambahkan ke inventory. Total: {inventory[namaItem]}");
        TampilkanInventory();
    }

    private void TampilkanInventory()
    {
        if (inventoryText == null)
        {
            Debug.LogWarning("Inventory Text belum di-assign di Inspector!");
            return;
        }

        string isi = "Inventory:\n";
        foreach (KeyValuePair<string, int> item in inventory)
        {
            isi += $"{item.Key}: {item.Value}\n";
        }

        inventoryText.text = isi;
    }
}
