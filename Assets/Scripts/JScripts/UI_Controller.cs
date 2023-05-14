// https://youtu.be/lBRwsl25jUs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    //public GameObject staminaBar;
    public Image staminaBar;
    public Player player;
    private PlayerStamina playerStamina;
    

    // Start is called before the first frame update
    void Start()
    {
        playerStamina = player.GetComponent<PlayerStamina>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the stamina bar
        staminaBar.fillAmount = playerStamina.GetStamina() / 100f;
    }
}
