using System.Collections;
using UnityEngine;

public class ShieldGenerator : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float radius = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnShield());
    }

    IEnumerator SpawnShield()
    {
        while (true)
        {
            Vector2 sp = Random.insideUnitCircle * radius;
            Instantiate(shieldPrefab, sp, Quaternion.identity, transform);
            yield return new WaitForSeconds(10f);
        }
    }
}
