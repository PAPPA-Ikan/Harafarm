using UnityEngine;

public class Tanaman : MonoBehaviour
{
    public string namaTanaman;
    public int hasilJual;
    public bool sudahMatang = false;

    private Animator animator;
    private int tahapSekarang = 0;
    private int totalTahap = 3; // 0,1,2 → 3 matang
    private float waktuTumbuh = 60f; // default: 1 menit
    private float durasiPerTahap;
    private float timer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetDurasiTumbuh(waktuTumbuh); // Gunakan default jika belum diset
        animator.SetInteger("Stage", tahapSekarang);
    }

    public void SetDurasiTumbuh(float durasi)
    {
        waktuTumbuh = durasi;
        durasiPerTahap = waktuTumbuh / totalTahap;
    }

    void Update()
    {
        if (sudahMatang) return;

        timer += Time.deltaTime;

        // Cek apakah waktunya naik tahap
        int tahapBaru = Mathf.FloorToInt(timer / durasiPerTahap);

        if (tahapBaru > tahapSekarang && tahapBaru <= totalTahap)
        {
            tahapSekarang = tahapBaru;
            animator.SetInteger("Stage", tahapSekarang);

            if (tahapSekarang == totalTahap)
            {
                sudahMatang = true;
            }
        }
    }

    public void Panen(bool sumbang = false)
    {
        if (!sudahMatang) return;

        var data = GameManager.instance.gameData;
        if (!sumbang)
        {
            data.coins += hasilJual;
        }

        GameManager.instance.SaveGame();
        Destroy(gameObject);
    }

    public void Disiram()
    {
        Debug.Log("Tanaman disiram. (Bisa dikembangkan untuk mempercepat tumbuh)");
    }
}
