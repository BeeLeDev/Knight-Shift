// https://youtu.be/HxD8pK0Cw44

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public UI_Controller ui;

    private Player player;
    private void Start() 
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col) //.gameObject.name == "PlayerAttackHitbox(Clone)")
            SceneManager.LoadScene(1);
    }

    private void Update() 
    {
        // turn on death text
        if (player.GetHealth() <= 0){
            ui.text.enabled = true;
            Invoke("LoadHub", 3);
        }
        if (GameObject.FindGameObjectWithTag("Boss").GetComponent<Enemy>().GetHealth() <= 0)
        {
            ui.text.text = "Level Completed";
            ui.text.enabled = true;
        }
    }

    void LoadHub(){
        SceneManager.LoadScene(0);
    }
}


    