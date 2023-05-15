using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    void Update()
    {
        //Debug.Log(menuVisibility);
        // use 'Esc' key to open and close Menu
        if (Input.GetKeyDown(KeyCode.Escape) && !gameObject.GetComponent<UIDocument>().enabled)
        {
            gameObject.GetComponent<UIDocument>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameObject.GetComponent<UIDocument>().enabled)
        {
            gameObject.GetComponent<UIDocument>().enabled = false;
        }
    }
}