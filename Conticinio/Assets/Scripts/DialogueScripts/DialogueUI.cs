using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    // Se encagarga de la parte visual

    public Conversation conversation; // conversacion ActualMostrada
    [SerializeField]
    float _textSpeed = 10;


    [SerializeField] GameObject convContainer;
    [SerializeField] GameObject cuestionContainer;

    [SerializeField] Image speakIm;
    [SerializeField] TextMeshProUGUI names;
    [SerializeField] TextMeshProUGUI convText;

    [SerializeField] Button continueButtom;
    [SerializeField] Button gobackButtom;

    public int localin = 0; // recorre cada dialogo dentro de la conversacion actual

    public void Start()
    {
        convContainer.SetActive(true);
        cuestionContainer.SetActive(false);

        continueButtom.gameObject.SetActive(true);
        gobackButtom.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TextActualize(1);
        }
    }
    public void TextActualize(int behaviour)
    {
        convContainer.SetActive(true);
        cuestionContainer.SetActive(false);

        switch (behaviour)
        {
            case -1 :
                if(localin > 0)
                {
                    print("dialogo anterior");
                    localin--;
                    names.text = conversation.dialogues[localin]._character.nombre;
                    StopAllCoroutines();
                    StartCoroutine(WriteText());
                    //convText.text = conversation.dialogues[localin].dialogue;
                    speakIm.sprite = conversation.dialogues[localin]._character.imagen;

                    //si necesario meter sonido aca
                    //if(conversation.dialogues[localin].sounds != null)

                    gobackButtom.gameObject.SetActive(localin > 0);
                     
                }
                 DialogueManager.speakerActual.dialLocalIn = localin;
                break;

            case 0:
                print("dialogo actualizado");
                names.text = conversation.dialogues[localin]._character.nombre;
                StopAllCoroutines();
                StartCoroutine(WriteText());
                //convText.text = conversation.dialogues[localin].dialogue;
                speakIm.sprite = conversation.dialogues[localin]._character.imagen;

                //si necesario meter sonido aca
                //if(conversation.dialogues[localin].sounds != null)

                gobackButtom.gameObject.SetActive(localin > 0);

                if(localin >= conversation.dialogues.Length - 1)
                {
                    continueButtom.GetComponentInChildren<TextMeshProUGUI>().text = "-->";
                }
                else
                {
                    continueButtom.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
                }
                break;

            case 1:
                if(localin < conversation.dialogues.Length - 1)
                {
                    print("Dialogo Siguiente");
                    localin++;
                    names.text = conversation.dialogues[localin]._character.nombre;
                    StopAllCoroutines();
                    StartCoroutine(WriteText());

                    speakIm.sprite = conversation.dialogues[localin]._character.imagen;

                    gobackButtom.gameObject.SetActive(localin > 0);

                    if (localin >= conversation.dialogues.Length - 1)
                    {
                        continueButtom.GetComponentInChildren<TextMeshProUGUI>().text = "-->";
                    }
                    else
                    {
                        continueButtom.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
                    }
                }
                else
                {
                    print("Dialogo Terminado");
                    localin = 0;
                    DialogueManager.speakerActual.dialLocalIn = 0;
                    conversation.finish = true;
                    ////
                    ///
                    if(conversation.question != null)
                    {
                        convContainer.SetActive(false);
                        cuestionContainer.SetActive(true);
                        var quest = conversation.question;
                        DialogueManager.instance._cuestionController.ActivateButtons(quest.options.Length, quest.question, quest.options);
                        return;
                    }
                    ////
                    DialogueManager.instance.ShowUI(false);
                    return;


                }

                DialogueManager.speakerActual.dialLocalIn = localin;

              

                break;
            default: Debug.LogError("no se aceptan valores fuera de -1,0,1");
                break;
        }
    }

    IEnumerator WriteText()
    {
        convText.maxVisibleCharacters = 0;
        convText.text = conversation.dialogues[localin].dialogue;
        convText.richText = true;
        for (int i = 0; i < conversation.dialogues[localin].dialogue.ToCharArray().Length; i++)
        {
            convText.maxVisibleCharacters++;
            yield return new WaitForSeconds(0.75f / _textSpeed);
        }
    }

}
