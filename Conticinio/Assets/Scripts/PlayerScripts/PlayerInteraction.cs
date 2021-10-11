using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    GameObject currentInteraction = null;

    public GameObject Interation { get { return currentInteraction; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //currentInteraction = collision.gameObject;
            
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if(collision.gameObject == currentInteraction)
            {
               // currentInteraction = null;
            }
        }
    }
}
