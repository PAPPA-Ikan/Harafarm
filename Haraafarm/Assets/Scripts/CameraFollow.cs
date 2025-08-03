using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Pemain yang akan diikuti
    public float smoothSpeed = 0.125f; // Kehalusan gerakan kamera
    public Vector3 offset; // Jarak posisi kamera dari player

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Jika kamu hanya ingin kamera bergerak di sumbu X dan Y (2D), gunakan ini:
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
