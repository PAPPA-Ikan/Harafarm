using UnityEngine;
using UnityEngine.UI;

public class ToolButton : MonoBehaviour
{
    public ToolType toolType;
    public PanelBenihUI panelBenihUI; // drag dari inspector

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnToolClick);
    }

    void OnToolClick()
    {
        ToolManager.instance.SetTool((int)toolType);

        if (toolType == ToolType.Tanam)
        {
            panelBenihUI.Show(); // tampilkan panel pilih benih
        }
    }
}
