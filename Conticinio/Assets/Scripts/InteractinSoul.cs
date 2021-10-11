using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractinSoul : MonoBehaviour
{

    [SerializeField] GameObject _startImage;
    public void ShowInitialText()
    {
        _startImage.SetActive(true);
    }
}
