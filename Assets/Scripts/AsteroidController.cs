using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 target;
    private Vector2 moveDir;
    public Sprite[] asteroidSprites;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sr.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            target = player.transform.position;
        }
        moveDir = (target - (Vector2)transform.position).normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDir * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
