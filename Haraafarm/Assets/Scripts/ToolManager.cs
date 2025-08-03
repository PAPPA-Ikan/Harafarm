using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType { None, Tanam, Siram, Panen, Hapus }

public class ToolManager : MonoBehaviour
{
    public static ToolManager instance;

    public ToolType currentTool = ToolType.None;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void SetTool(int toolIndex)
    {
        currentTool = (ToolType)toolIndex;
        Debug.Log("Alat aktif: " + currentTool);
    }

    public void ClearTool()
    {
        Debug.Log("Alat dinonaktifkan");
        currentTool = ToolType.None;
    }

    public void ResetToolIfNotLahan(GameObject obj)
    {
        if (obj == null || obj.GetComponent<LahanInteractable>() == null)
        {
            Debug.Log("Klik objek null, alat direset.");
            ClearTool();
        }
    }


}

