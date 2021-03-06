using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 respawnPosition;
    Vector3 _velocity;
    public Control _control;
    [SerializeField]float _timeToSlow;
    [SerializeField] PlayerInteraction _interaction;
    [SerializeField]Animator _anim;


    #region GrounCheckerStuff
    GroundedChecker _ground;
    [SerializeField] float _checkrad;
    [SerializeField] Transform _grounded;
    [SerializeField]  LayerMask _groundLayer;
    [SerializeField] SpriteRenderer _render;
    #endregion

    #region MovementStuff
    Movement _movement;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _jumpForce;
    [SerializeField] float _speed;
    #endregion

    private void Start()
    {
        
        _ground = new GroundedChecker(_grounded, _checkrad, _groundLayer,this.gameObject);
        _movement = new Movement(_rb,this.transform,_speed,_jumpForce);
        _control = new Control(_movement, _ground,_render,_timeToSlow,_interaction,_anim);
        respawnPosition = Vector3.zero;

    }
    private void Update()
    {
        _control.OnUpdate(); 
    }

    public void RespawnPoint(Transform t)
    {
        respawnPosition = t.position;
    }

    public  void Respawn()
    {
        this.transform.position = respawnPosition;
    }


}
