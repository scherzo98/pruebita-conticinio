using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker
{
    Transform _isGroundedChecker;
    float _checkGroundRadius;
    bool isGrounded;
    LayerMask _groundLayer;

    public GroundedChecker(Transform t, float checkRad,LayerMask groundlayer)
    {
        _isGroundedChecker = t;
        _checkGroundRadius = checkRad;
        _groundLayer = groundlayer;

    }
    public bool CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(_isGroundedChecker.position, _checkGroundRadius, _groundLayer);
        if (collider != null)
             return isGrounded = true;
        else
            return isGrounded = false;
    }
}
