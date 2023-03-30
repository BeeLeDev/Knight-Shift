using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    // hit points
    public int health;
    // how fast the Player can move
    public float moveSpeed;
    // this is for the SmoothDamp() function in 'CameraMovement.cs'
    [HideInInspector]
    public Vector3 velocity;



    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        moveSpeed = 5.0f;
    }
}
