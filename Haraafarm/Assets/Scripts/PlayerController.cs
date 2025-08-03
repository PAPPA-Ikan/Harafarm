using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public VirtualJoystick joystick;
    public bool BawaAir = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ambil input dari joystick
        Vector2 movement = new Vector2(joystick.Horizontal(), joystick.Vertical());

        // Gerakkan player
        rb.velocity = movement * speed;

        // Karakter selalu tegak (tidak rotasi ke arah gerakan)
        // Jadi tidak ada perubahan rotasi seperti transform.up = movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sumur"))
        {
            BawaAir = true;
            Debug.Log("Air berhasil diambil!");
        }
    }
}
