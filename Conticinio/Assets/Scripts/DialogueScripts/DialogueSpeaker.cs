using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityExtensions;

public class DialogueSpeaker : MonoBehaviour
{
    //[ReorderableList]
    public List<Conversation> availableConversation = new List<Conversation>();

    [SerializeField] int indexConversation = 0;
 

    public int dialLocalIn = 0;

    private void Start()
    {

        indexConversation = 0;
        dialLocalIn = 0;
    }


    //REVISAR ESTO

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10 && Input.GetKeyDown(KeyCode.E))
        {
            Talk();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 )
        {
            DialogueManager.instance.ShowUI(false);
        }
    }

    public void Talk()
    {
        if(indexConversation <= availableConversation.Count - 1)
        {
            if (availableConversation[indexConversation].unlock)
            {
                if (availableConversation[indexConversation].finish)
                {
                    if (ActualizeConversation())
                    {
                        DialogueManager.instance.ShowUI(true);
                        DialogueManager.instance.SetConversation(availableConversation[indexConversation], this);
                    }
                    DialogueManager.instance.SetConversation(availableConversation[indexConversation], this);
                    return;
                }
                DialogueManager.instance.ShowUI(true);
                DialogueManager.instance.SetConversation(availableConversation[indexConversation], this);

            }
            else
            {
                Debug.LogWarning("conversacionBloqueada");
                DialogueManager.instance.ShowUI(false);
            }
        }
        else
        {
            print("fin dialogo");
            DialogueManager.instance.ShowUI(false);
          
        }
       
    }
    
    bool ActualizeConversation()
    {
        if (!availableConversation[indexConversation].reusable)
        {
            if (indexConversation < availableConversation.Count - 1)
            {
                indexConversation++;
                return true;
            }
            else
            {
                this.gameObject.SetActive(false);// crear metodo de movimiento del enemigo que vuelve hacia fuera del mapa y se apague
                return false;
            }


        }
        else
        {
            this.gameObject.SetActive(false);// crear metodo de movimiento del enemigo que vuelve hacia fuera del mapa y se apague
            return true;
        }

        
    }

}
