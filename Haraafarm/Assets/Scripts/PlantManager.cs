using UnityEngine;
using System.Collections;

[System.Serializable]
public class TanamanInfo
{
    public string nama;
    public GameObject prefab;
    public float totalDurasiTumbuh; // dalam detik
}

public class PlantManager : MonoBehaviour
{
    public string selectedTanaman;
    public GameObject prefabTomat;
    public GameObject prefabJagung;
    public GameObject prefabWortel;

    public static PlantManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void SetSelectedTanaman(string nama)
    {
        selectedTanaman = nama;
        Debug.Log("Tanaman dipilih: " + nama);
    }

    public GameObject Tanam(Vector3 posisi, GameObject lahanObj)
    {
        GameObject prefab = null;
        float durasi = 0f;

        switch (selectedTanaman)
        {
            case "Tomat":
                prefab = prefabTomat;
                durasi = 60f;
                break;
            case "Jagung":
                prefab = prefabJagung;
                durasi = 120f;
                break;
            case "Wortel":
                prefab = prefabWortel;
                durasi = 180f;
                break;
            default:
                Debug.LogWarning("Tanaman belum dipilih");
                return null;
        }

        LahanInteractable lahan = lahanObj.GetComponent<LahanInteractable>();

        // HAPUS TANAMAN LAMA JIKA ADA
        if (lahan.tanamanDiLahan != null)
        {
            Destroy(lahan.tanamanDiLahan);
            Debug.Log("Tanaman lama dihapus.");
        }

        GameObject tanaman = Instantiate(prefab, posisi, Quaternion.identity);

        lahan.tanamanDiLahan = tanaman;
        lahan.siapDipanen = false;

        Animator animator = tanaman.GetComponent<Animator>();
        if (animator != null)
        {
            float speed = 1f / durasi;
            animator.SetFloat("GrowSpeed", speed);
            animator.SetTrigger("MulaiTumbuh");
        }
        else
        {
            Debug.LogWarning("Animator tidak ditemukan di prefab: " + prefab.name);
        }

        StartCoroutine(ActivatePanen(lahan, durasi));

        selectedTanaman = "";
        ToolManager.instance.ClearTool();

        return tanaman;
    }


    IEnumerator ActivatePanen(LahanInteractable lahan, float delay)
    {
        Debug.Log("Menunggu selama " + delay + " detik...");
        yield return new WaitForSeconds(delay);
        lahan.siapDipanen = true;
        Debug.Log("Tanaman siap dipanen!");
    }
}
