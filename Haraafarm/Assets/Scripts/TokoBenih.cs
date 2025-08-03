using UnityEngine;

public class TokoBenih : MonoBehaviour
{
    public void BeliBenih(string namaBenih, int harga)
    {
        var data = GameManager.instance.gameData;
        if (data.coins >= harga)
        {
            data.coins -= harga;
            if (data.inventory.ContainsKey(namaBenih))
                data.inventory[namaBenih]++;
            else
                data.inventory.Add(namaBenih, 1);
            GameManager.instance.SaveGame();
            Debug.Log("Berhasil beli: " + namaBenih);
        }
        else
        {
            Debug.Log("Uang tidak cukup!");
        }
    }

}
