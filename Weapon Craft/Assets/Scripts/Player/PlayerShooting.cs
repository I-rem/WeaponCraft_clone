using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletForce = 20f; 
    public float shootInterval = 1f; 

    private float shootTimer = 0f;

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Shoot(); 
            shootTimer = 0f; 
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
