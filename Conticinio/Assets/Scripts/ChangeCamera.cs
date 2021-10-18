using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera _camera;
    public int count;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && count == 0)
        {
            _camera.ChangeOffset();
            

        }
     
    }
}
