using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTransform : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] Player player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 10)
        {
            _anim.SetBool("pass", true);
            player.RespawnPoint(this.transform);
            
        }


    }
}
