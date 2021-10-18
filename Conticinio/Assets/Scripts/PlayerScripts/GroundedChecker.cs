using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker
{
    Transform _isGroundedChecker;
    float _checkGroundRadius;
   
    LayerMask _groundLayer;
    GameObject _player;

    public GroundedChecker(Transform t, float checkRad,LayerMask groundlayer,GameObject p)
    {
        _isGroundedChecker = t;
        _checkGroundRadius = checkRad;
        _groundLayer = groundlayer;
        _player = p;

    }
    public bool CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(_isGroundedChecker.position, _checkGroundRadius, _groundLayer);
        if (collider != null)
        {
            _player.transform.parent = collider.gameObject.transform;
            return true;

        }
             
        else
            return false;
    }
}
