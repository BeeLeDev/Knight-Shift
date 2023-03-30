using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // the Player
    public GameObject player;
    // the PlayerCamera
    public Camera customCamera;
    // Approximately the time it will take to reach the target. A smaller value will reach the target faster
    public float smoothTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the new camera position using smoothing
        Vector3 targetPosition = Vector3.SmoothDamp(
            customCamera.transform.position, 
            new Vector3(player.transform.position.x, 
            player.transform.position.y, 
            customCamera.transform.position.z), 
            // don't know why we need velocity, but we want to use the Player's velocity cause they have a RigidBody which keeps velocity somewhere probably
            ref player.GetComponent<PlayerClass>().velocity, 
            smoothTime);

        // Move the camera to follow the player
        customCamera.transform.position = targetPosition;
    }
}
