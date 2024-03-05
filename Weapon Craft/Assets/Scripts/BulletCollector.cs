using UnityEngine;

public class BulletCollector : MonoBehaviour
{
    public int maxBullets = 7; 
    public GameObject bulletPrefab; 

    private int currentBullets = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("Test");
            AddBullet();
            Destroy(collision.collider);
           
        }
    }

    public void AddBullet()
    {
        currentBullets++;

        if (currentBullets >= maxBullets)
        {
            Destroy(gameObject);
        }
    }
}
