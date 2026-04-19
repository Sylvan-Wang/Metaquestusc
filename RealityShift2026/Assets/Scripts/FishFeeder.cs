using System.Collections.Generic;
using UnityEngine;

public class FishFeeder : MonoBehaviour
{
    public List<GameObject> pelletPrefabs;
    public Transform spawnPoint;

    public float tiltThreshold = 45f;

    private bool hasDispensed = false;

    void Update()
    {
        float angle = transform.eulerAngles.x;
        if (angle > 180) angle -= 360;

        float absAngle = Mathf.Abs(angle);

        // DISPENSE
        if (absAngle > tiltThreshold && !hasDispensed)
        {
            SpawnPellet();
            hasDispensed = true;
        }

        // RESET (important fix)
        if (absAngle < tiltThreshold * 0.5f)
        {
            hasDispensed = false;
        }
    }

    void SpawnPellet()
    {
        if (pelletPrefabs.Count == 0) return;

        GameObject prefab = pelletPrefabs[Random.Range(0, pelletPrefabs.Count)];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}