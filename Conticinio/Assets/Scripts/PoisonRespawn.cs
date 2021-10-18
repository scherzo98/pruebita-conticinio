using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonRespawn : MonoBehaviour
{
    [SerializeField] GameObject _fade;
    [SerializeField] Player _player;
    [SerializeField] float TimeToWait;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            _fade.SetActive(true);
            _player._control._states = ControlStates.EscapeFromSlowliness;
            StartCoroutine(FadeIn());

        }
    }

    IEnumerator FadeIn()
    {
       
        _player.Respawn();
       yield return new  WaitForSeconds(TimeToWait);
        _player._control._states = ControlStates.Moving;
        _fade.SetActive(false);
    }
}
