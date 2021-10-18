using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanisPlatform : MonoBehaviour
{
    public Animator _anim;
  
    [SerializeField] float timeToWait;
    [SerializeField] float TimeToRespawn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("helloZERO");
            StartCoroutine(PlatAction());
        }
              

    }
  
    public IEnumerator PlatAction()
    {
        Debug.Log("hello");
        yield return new WaitForSeconds(timeToWait);
        _anim.SetBool("onPlat", true);
        yield return new WaitForSeconds(TimeToRespawn);
        _anim.SetBool("onPlat", false);




    }

}
