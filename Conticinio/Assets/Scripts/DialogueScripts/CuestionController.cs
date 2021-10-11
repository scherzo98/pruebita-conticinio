using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CuestionController : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPref;
    [SerializeField] TextMeshProUGUI pregtext;
    [SerializeField] Transform optionContainer;
    private List<Button> poolButtons = new List<Button>();

    private void Start()
    {
        
    }

    public void ActivateButtons(int cantidad,string title,Option[] optiones)
    {
        pregtext.text = title;
        if(poolButtons.Count >= cantidad)
        {
            
            for (int i = 0; i < poolButtons.Count; i++)
            {
                if (i < cantidad)
                {
                    poolButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = optiones[i].option;
                    poolButtons[i].onClick.RemoveAllListeners();
                    Conversation co = optiones[i].convResult;
                    poolButtons[i].onClick.AddListener(() => SetButtnFunc(co));
                    poolButtons[i].gameObject.SetActive(true);

                }
                else
                {
                    poolButtons[i].gameObject.SetActive(false);
                }

            }
        }
        else
        {
            int cantidadRestante = (cantidad - poolButtons.Count);
            for (int i = 0; i < cantidadRestante; i++)
            {
                var newButton = Instantiate(buttonPref, optionContainer).GetComponent<Button>();
                newButton.gameObject.SetActive(true);
                poolButtons.Add(newButton);
            }
            ActivateButtons(cantidad, title, optiones);
        }
    }

    public void SetButtnFunc(Conversation co)
    {
        DialogueManager.instance.SetConversation(co, null);
    }
}

