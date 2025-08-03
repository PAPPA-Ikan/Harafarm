using UnityEngine;
using UnityEngine.UI;

public class PanelBenihUI : MonoBehaviour
{
    public GameObject panel;
    public Button wortelButton;
    public Button jagungButton;
    public Button tomatButton;

    private PlantManager plantManager;

    void Start()
    {
        plantManager = FindObjectOfType<PlantManager>();

        wortelButton.onClick.AddListener(() => PilihTanaman("Tomat"));
        jagungButton.onClick.AddListener(() => PilihTanaman("Jagung"));
        tomatButton.onClick.AddListener(() => PilihTanaman("Wortel"));
    }

    public void Show()
    {
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    void PilihTanaman(string namaTanaman)
    {
        plantManager.SetSelectedTanaman(namaTanaman);
        Hide(); // Tutup panel setelah memilih
    }
}
