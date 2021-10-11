using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
   public static DialogueManager instance { get; private set; }
   public static DialogueSpeaker speakerActual;

    public CuestionController _cuestionController;

    [SerializeField] DialogueUI dialUi;

    [SerializeField] GameObject player;

   

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        dialUi = FindObjectOfType<DialogueUI>();
        _cuestionController = FindObjectOfType<CuestionController>();
    }
    private void Start()
    {
        ShowUI(false);
        //player.GetComponent<DialogueSpeaker>().Talk();
    }

    public void ShowUI(bool show)
    {
        dialUi.gameObject.SetActive(show);
        if (!show)
        {
           dialUi.localin = 0;
           player.gameObject.GetComponent<Player>()._control._states = ControlStates.Moving;
        }
        else
        {
            player.gameObject.GetComponent<Player>()._control._states = ControlStates.TextInteraction;
        }
    }
    public void SetConversation(Conversation conv, DialogueSpeaker speaker)
    {
        if(speaker != null)
        {
            speakerActual = speaker;
        }
        else
        {
            // vengo de una  pregunta entonces reseteo LOCALIN para recorrer de nuevo la conv
            dialUi.conversation = conv;
            dialUi.localin = 0;
            dialUi.TextActualize(0);
        }
        if(conv.finish && !conv.reusable)
        {
            dialUi.conversation = conv;
            dialUi.localin = conv.dialogues.Length;
            dialUi.TextActualize(1);
        }
        else
        {
            dialUi.conversation = conv;
            dialUi.localin = speakerActual.dialLocalIn;
            dialUi.TextActualize(0);

        }

        /////
    }


    ///
    public void ChangeStateReuse(Conversation conv, bool desireState)
    {
        conv.reusable = desireState;
    }

    public void BlockingUnblockingConversation(Conversation conv, bool unlock)
    {
        conv.unlock = unlock;
    }
}
