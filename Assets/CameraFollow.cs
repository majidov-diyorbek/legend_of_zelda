using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Reference to the player's transform
    public Vector3 offset;     // Offset distance between the player and camera

    void LateUpdate()
    {
        // Set the camera's position relative to the player's position with the offset
        transform.position = player.position + offset;
        
        // Optional: Make the camera always look at the player
        transform.LookAt(player);
    }
}