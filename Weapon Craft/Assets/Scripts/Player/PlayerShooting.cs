using UnityEngine;
using System.Collections;


public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public float maxShootingDistance = 10f;
    public float shootInterval = 0.5f;

    private float shootTimer = 0f;

    public float animationDuration = 0.2f;
    public float animationIntensity = 5f;

    private Transform playerTransform;

    private bool isAnimating = false;

    private void Start()
    {
        playerTransform = transform;
    }

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f; // Reset shoot timer
        }
    }

    void Shoot()
    {
        if (!isAnimating)
            StartCoroutine(ShootAnimationCoroutine());

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, maxShootingDistance / bulletForce);
    }

    IEnumerator ShootAnimationCoroutine()
    {

        isAnimating = true;

        Quaternion initialRotation = playerTransform.rotation;
        Quaternion targetRotation = Quaternion.Euler(playerTransform.eulerAngles + Vector3.left * animationIntensity);

        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            playerTransform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        playerTransform.rotation = initialRotation;

        isAnimating = false;
    }

    public void ApplyBonus(float bonus, int type)
    {
        if (type == 0)
        {
            shootInterval -= bonus;
            if (shootInterval < 0)
                shootInterval = 0;
        }
        else if (type == 1)
        {
            maxShootingDistance += bonus;
        }
            
    }
}

