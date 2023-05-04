using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // the Player
    public GameObject player;
    // approximately the time it will take to reach the target. a smaller value will reach the target faster
    public float smoothTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the new camera position using smoothing
        Vector3 targetPosition = Vector3.SmoothDamp(
            transform.position, 
            new Vector3(player.transform.position.x, 
            player.transform.position.y, 
            transform.position.z), 
            // don't know why we need velocity, but we want to use the Player's velocity cause they have a RigidBody which keeps velocity somewhere probably

            // ** WHAT IS 'ref'? **
            ref player.GetComponent<Player>().velocity, 
            smoothTime);

        // Move the camera to follow the player
        transform.position = targetPosition;
    }
}
