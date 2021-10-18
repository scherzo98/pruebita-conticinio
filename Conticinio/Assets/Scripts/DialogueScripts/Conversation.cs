using UnityEngine;
//using UnityExtensions;

[CreateAssetMenu(fileName = "Conversacion", menuName = "Sistema de Dialogo/Nueva Conversacion")]
public class Conversation : ScriptableObject
{
    [System.Serializable]
    public struct Linea
    {
        public Character _character;

        [TextArea(3, 5)]
        public string dialogue;
    }

    public bool unlock;
    public bool finish;
    public bool reusable;
   
    public Linea[] dialogues;

 
    public Question question;
    
   
   
}
