using UnityEngine;
using UnityEngine.EventSystems;

public class DragTool : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalPosition;

    public ToolType toolType;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition; // simpan posisi saat mulai drag
        ToolManager.instance.SetTool((int)toolType); // aktifkan tool
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ToolManager.instance.ClearTool();
        rectTransform.anchoredPosition = originalPosition; // kembali ke posisi awal
    }
}
