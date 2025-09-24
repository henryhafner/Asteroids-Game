using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float movementX;
    private float movementY;
    public float speed = 3f;
    private Camera mainCam;
    private Vector3 mousePos;
    private Vector2 spawnLoc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        spawnLoc = transform.position;
    }

    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotz - 90f);
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY).normalized;
        rb.linearVelocity = movement * speed;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            ShieldController shield = GetComponentInChildren<ShieldController>();
            if (shield == null)
            {
                Respawn();
            }
            Destroy(collision.gameObject);
        }
    }

    void Respawn()
    {
        transform.position = spawnLoc;
        rb.linearVelocity = Vector2.zero;
        movementX = 0;
        movementY = 0;
    }
}
