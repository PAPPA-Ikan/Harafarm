using UnityEngine;

public class LahanInteractable : MonoBehaviour
{
    public GameObject tombolTanam;
    public GameObject tombolSiram;
    public GameObject tombolPanen;
    public GameObject tombolHapus;

    public GameObject tanamanDiLahan;
    public bool sudahDisiram = false;
    public bool siapDipanen = false;

    public GameObject notifikasiSiapPanen;

    private bool playerDiDekat = false;

    void Start()
    {
        if (tanamanDiLahan != null && !tanamanDiLahan.activeInHierarchy)
        {
            Debug.Log("Tanaman tidak aktif, reset referensi.");
            tanamanDiLahan = null;
        }
    }

    void Update()
    {
        if (tanamanDiLahan == null && notifikasiSiapPanen != null)
        {
            notifikasiSiapPanen.SetActive(false);
        }
        else if (siapDipanen && notifikasiSiapPanen != null)
        {
            notifikasiSiapPanen.SetActive(true);
        }
        else if (notifikasiSiapPanen != null)
        {
            notifikasiSiapPanen.SetActive(false);
        }

        if (playerDiDekat)
        {
            UpdateTombolState();
        }
    }

    void OnMouseDown()
    {
        if (!playerDiDekat) return;

        ToolType alat = ToolManager.instance.currentTool;

        switch (alat)
        {
            case ToolType.Tanam:
                if (tanamanDiLahan == null || !tanamanDiLahan.activeInHierarchy)
                {
                    PlantManager pm = FindObjectOfType<PlantManager>();
                    tanamanDiLahan = pm.Tanam(transform.position, gameObject);
                    sudahDisiram = false;
                    siapDipanen = false;
                    Debug.Log("Tanaman ditanam.");
                }
                else
                {
                    Debug.Log("Lahan sudah ada tanaman.");
                }
                break;

            case ToolType.Siram:
                if (tanamanDiLahan != null && !sudahDisiram)
                {
                    sudahDisiram = true;
                    Debug.Log("Tanaman disiram.");
                    Invoke(nameof(SiapkanPanen), 5f);
                }
                else if (tanamanDiLahan == null)
                {
                    Debug.Log("Tidak ada tanaman untuk disiram.");
                }
                break;

            case ToolType.Panen:
                if (tanamanDiLahan != null && siapDipanen)
                {
                    string namaItem = tanamanDiLahan.name.Replace("(Clone)", "").Trim();

                    Destroy(tanamanDiLahan);
                    tanamanDiLahan = null;
                    sudahDisiram = false;
                    siapDipanen = false;

                    InventoryManager.instance.TambahHasilPanen(namaItem);

                    if (notifikasiSiapPanen != null)
                        notifikasiSiapPanen.SetActive(false);

                    Debug.Log($"Tanaman dipanen! Ditambahkan ke inventory: {namaItem}");
                }
                else
                {
                    Debug.Log("Tanaman belum siap dipanen.");
                }
                break;

            case ToolType.Hapus:
                if (tanamanDiLahan != null)
                {
                    Destroy(tanamanDiLahan);
                    tanamanDiLahan = null;
                    sudahDisiram = false;
                    siapDipanen = false;
                    if (notifikasiSiapPanen != null)
                        notifikasiSiapPanen.SetActive(false);
                    Debug.Log("Tanaman dihapus!");
                }
                break;
        }

        UpdateTombolState();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDiDekat = true;
            UpdateTombolState();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDiDekat = false;
            SembunyikanSemuaTombol();
        }
    }

    void UpdateTombolState()
    {
        if (!playerDiDekat)
        {
            SembunyikanSemuaTombol();
            return;
        }

        SetTombol(tombolTanam, true);
        SetTombol(tombolSiram, true);
        SetTombol(tombolPanen, true);
        SetTombol(tombolHapus, true);
    }

    void SembunyikanSemuaTombol()
    {
        SetTombol(tombolTanam, false);
        SetTombol(tombolSiram, false);
        SetTombol(tombolPanen, false);
        SetTombol(tombolHapus, false);
    }

    void SetTombol(GameObject tombol, bool aktif)
    {
        if (tombol != null)
        {
            tombol.SetActive(aktif);
        }
    }

    void SiapkanPanen()
    {
        siapDipanen = true;
        Debug.Log("Tanaman siap dipanen!");
    }
}
