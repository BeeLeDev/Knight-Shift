// https://youtu.be/HxD8pK0Cw44

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col) //.gameObject.name == "PlayerAttackHitbox(Clone)")
            SceneManager.LoadScene(1);
    }
}
