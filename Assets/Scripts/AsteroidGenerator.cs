using System.Collections;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float radius = 5;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(SpawnAsteroids());
    }

    Vector2 AsteroidSpawnLoc(float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            Vector2 sp = (Vector2)player.transform.position + AsteroidSpawnLoc(radius);
            Instantiate(asteroidPrefab, sp, Quaternion.identity, transform);
            yield return new WaitForSeconds(1f);
        }
    }
}
