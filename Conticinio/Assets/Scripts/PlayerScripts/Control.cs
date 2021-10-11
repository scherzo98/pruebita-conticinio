using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimerCloack;

public enum ControlStates
{
    Moving,
    TextInteraction,
    EscapeFromSlowliness
}
public class Control 
{
    public ControlStates _states;
    Movement _movement;
    GroundedChecker _checkGround;
    SpriteRenderer _render;
    TimerMethod _timer;
    PlayerInteraction _interaction;
    float _timeToSlow;
    int _countToNormal;
    public Control(Movement m,GroundedChecker g,SpriteRenderer render,float time, PlayerInteraction p)
    {
        
        _movement = m;
        _checkGround = g;
        _render= render;
        _timeToSlow = time;
        _interaction = p;
        _timer = new TimerMethod();
        _states = ControlStates.Moving;

    }



    public void OnUpdate()
    {
        if(_states == ControlStates.Moving)
        {
            _checkGround.CheckIfGrounded();

            if (Input.GetKeyDown(KeyCode.Space) && _checkGround.CheckIfGrounded()== true)
                _movement.Jump();

            if (MovementInput() != Vector2.zero)
                _movement.Move(MovementInput());
            else
            {
                //si supera el tiempo pasa al estado de no me puedo mover

                if (_timer.Timer(_timeToSlow))
                {
                    _states = ControlStates.EscapeFromSlowliness;
                    _timer.passTime = 0;
                }
               
            }

            if (Input.GetKeyDown(KeyCode.E) && _interaction.Interation != null)
            {
                _interaction.Interation.SendMessage("ShowInitialText");
                _states = ControlStates.TextInteraction;
            }
                
        }
        if(_states == ControlStates.EscapeFromSlowliness)
        {
            
            if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
            {
                MovementInput();
                _countToNormal++;

            }
            if (_countToNormal > 5)
            {
                _states = ControlStates.Moving;
                _countToNormal = 0;

            }
                

        }
        if(_states == ControlStates.TextInteraction)
        {
            //if (_interaction.Interation == null) _states = ControlStates.Moving;

            if (Input.GetKeyDown(KeyCode.E))
            {

            }
              
        }
        

    }

    Vector2 MovementInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Flip(h);
        return new Vector2(h, v);
    }

    void Flip(float h)
    {
        
            if (h < 0)
            {
            _render.flipY = true;
            }
            if (h > 0)
            {
            _render.flipY = false;
            }
    }

   



}


