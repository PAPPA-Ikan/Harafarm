using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coins = 0;

    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    public Dictionary<string, int> harvested = new Dictionary<string, int>();
    // Daftar jumlah benih (seeds), misalnya: tomat, wortel, dll.
    public Dictionary<string, int> seeds = new Dictionary<string, int>();

    // Konstruktor inisialisasi default (opsional)
    public GameData()
    {
        // Contoh inisialisasi awal
        seeds["tomat"] = 5;
        seeds["wortel"] = 0;

        harvested["tomat"] = 0;
        harvested["wortel"] = 0;
    }
}
