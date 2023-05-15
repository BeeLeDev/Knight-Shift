// https://youtu.be/lBRwsl25jUs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public Player player;
    public Image staminaBar;
    public GameObject heart;
    public GameObject heartContainer;
    public TextMeshProUGUI text;

    private PlayerStamina playerStamina;
    private int playerHealth;
    private List<Image> hearts;

    // Start is called before the first frame update
    void Start()
    {
        playerStamina = player.GetComponent<PlayerStamina>();

        playerHealth = player.GetHealth();
        for (int i = 0; i < playerHealth; i++)
        {
            GameObject h = Instantiate(heart, heartContainer.transform);
        }

        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // update the stamina bar
        staminaBar.fillAmount = playerStamina.GetStamina() / 100f;

        // update the number of hearts
        if (playerHealth != player.GetHealth()){
            while (player.GetHealth() < playerHealth){ // remove hearts
                int temp = heartContainer.transform.childCount - 1;
                Destroy(heartContainer.transform.GetChild(temp).gameObject);
                playerHealth--;
            }
            while (player.GetHealth() > playerHealth){ // add hearts
                GameObject h = Instantiate(heart, heartContainer.transform);
                playerHealth++;
            }
        }

        // turn on death text
        if (player.GetHealth() == 0){
            text.enabled = true;
            Invoke("LoadHub", 5);
        }
    }

    void LoadHub(){
        SceneManager.LoadScene(0);
    }
}
