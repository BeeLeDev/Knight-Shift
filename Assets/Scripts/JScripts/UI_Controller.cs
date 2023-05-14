// https://youtu.be/lBRwsl25jUs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    //public GameObject staminaBar;
    public Image staminaBar;
    public GameObject heart;
    public GameObject heartContainer;
    public Player player;
    

    private PlayerStamina playerStamina;
    private int playerHealth;
    private List<Image> hearts;
        

    // Start is called before the first frame update
    void Start()
    {
        playerStamina = player.GetComponent<PlayerStamina>();
        playerHealth = player.GetHealth();
        for (int i = 0; i < playerHealth; i++){
            GameObject h = Instantiate(heart, heartContainer.transform);
            hearts.Add(h.GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // update the stamina bar
        staminaBar.fillAmount = playerStamina.GetStamina() / 100f;
    }
}
