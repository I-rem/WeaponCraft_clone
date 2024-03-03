using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // Calculate the target position including player's position on X and Z axes
        Vector3 targetpos = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);

        // Set the camera's position to the target position
        transform.position = targetpos;
    }
}
