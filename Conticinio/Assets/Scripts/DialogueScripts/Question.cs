using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityExtensions;
[System.Serializable]
public struct Option
{
    [TextArea(2, 4)]
    public string option;
    public Conversation convResult;
}

[CreateAssetMenu(fileName = "Pregunta", menuName ="Sistema de Dialogo/NuevaPregunta")]
public class Question : ScriptableObject
{
    [TextArea(3, 5)]
    public string question;
   // [ReorderableList]
    public Option[] options;
}
