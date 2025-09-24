using System.Collections;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float shieldDuration = 5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.SetParent(collision.transform);
            transform.localPosition = Vector3.zero;

            StartCoroutine(ShieldTimer());
        }
    }

    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(shieldDuration);
        Destroy(gameObject);
    }
}
