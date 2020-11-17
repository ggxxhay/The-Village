using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    public string Dialog;

    private bool isPlayerInRange;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(GlobalVar.KEYCODE_INTERACT) && isPlayerInRange){
            Debug.Log("E");
            if (DialogBox.activeInHierarchy)
            {
                DialogBox.SetActive(false);
            }
            else
            {
                DialogBox.SetActive(true);
                DialogText.text = Dialog;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            isPlayerInRange = false;
            DialogBox.SetActive(false);
        }
    }
}
