using UnityEngine;

public class DepMovementControl : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {

        // move the camera up when W is pressed
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }

        // move the camera down when S is pressed
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        }

        // move the camera right when D is pressed
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        // move the camera left when A is pressed
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
