using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    public float obstaclePushbackDistance = 2;
    public Rigidbody rb;

    float horizontalMultiplier = 2;
    float horizontalInput;

    // Define the boundaries within which the player can move
    public float minX = -5f;
    public float maxX = 5f;

    private bool obstacleCollisionDetected = false;
    private void FixedUpdate()
    {
        if (!alive) return;

        if (!obstacleCollisionDetected)
        {
            // Regular movement logic
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier * Time.fixedDeltaTime;
            Vector3 newPosition = rb.position + forwardMove + horizontalMove;

            // Clamp the player's position within the specified range
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            rb.MovePosition(newPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Set obstacle collision flag
            obstacleCollisionDetected = true;

            // Adjust the player's position immediately upon collision
            Vector3 awayFromObstacle = -transform.forward; // Move backward along local z-axis
            Vector3 newPosition = rb.position + awayFromObstacle * obstaclePushbackDistance;

            rb.MovePosition(newPosition);
            obstacleCollisionDetected = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

      //  if (transform.position.y < -5)
      //      Die();
    }

    /*
    public void Die()
    {
        alive = false;

        Invoke("Restart", 2);
    }
    */
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
