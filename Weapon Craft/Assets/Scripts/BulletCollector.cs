using UnityEngine;

public class BulletCollector : MonoBehaviour
{
    public int maxBullets = 7; // Maximum number of bullets the collector can hold
    public GameObject bulletPrefab; // Prefab of the bullet object to collect
    public Transform bulletSpawnPoint; // Point from which bullets will be spawned when collected

    private int currentBullets = 0; // Current number of collected bullets

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player touched the collector, collect the bullets
            CollectBullets();
        }
    }

    void CollectBullets()
    {
        // Destroy the collector object
        Destroy(gameObject);

        // Spawn bullets at the spawn point
        for (int i = 0; i < currentBullets; i++)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        }
    }

    public void AddBullet()
    {
        // Increment current bullets count
        currentBullets++;

        // If the current bullets count exceeds the maximum, collect the bullets
        if (currentBullets >= maxBullets)
        {
            CollectBullets();
        }
    }
}
