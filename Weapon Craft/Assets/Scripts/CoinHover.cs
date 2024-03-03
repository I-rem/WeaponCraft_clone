using UnityEngine;

public class CoinHover : MonoBehaviour
{
    public float hoverHeight = 0.5f; 
    public float hoverSpeed = 1f; 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        // Update the position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
