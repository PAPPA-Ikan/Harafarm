using UnityEngine;

public class GlobalInputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Klik kiri
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit == null || hit.GetComponent<LahanInteractable>() == null)
            {
                ToolManager.instance.ResetToolIfNotLahan(hit?.gameObject);
            }
        }
    }

    GameObject GetObjectUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}
