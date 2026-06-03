using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    public GameObject icePrefab;
    public float spawnInterval = 2f;
    public float spawnHeight = 5f;
    public float minX = -2f;
    public float maxX = 8f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnIce), 1f, spawnInterval);
    }

    void SpawnIce()
    {
        float x = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(x, spawnHeight, 0f);

        Instantiate(icePrefab, spawnPosition, Quaternion.identity);
    }
}