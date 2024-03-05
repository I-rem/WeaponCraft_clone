using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int coinsCollected = 0; 
    public AudioClip collectSound; 

    private AudioSource audioSource;
    private Rigidbody rb;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) 
        {

            Destroy(other.gameObject);
            coinsCollected++;

            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // We can add more behavior here, like updating UI

            //Debug.Log("Coin collected! Total coins: " + coinsCollected);
        }
    }
}
