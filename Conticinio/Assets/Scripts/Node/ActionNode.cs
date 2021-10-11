using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Actions
{
    Action1,
    Action2,
    Action3,
    Action4
}
public class ActionNode : Node
{
    public Actions myAction;

    public override void Execute(Player p)
    {
        switch (myAction)
        {
            case Actions.Action1:
                //lo que tenga que hacer
                break;
            case Actions.Action2:
                //lo que tenga que hacer
                break;
            case Actions.Action3:
                //lo que tenga que hacer
                break;
            case Actions.Action4:
                //lo que tenga que hacer
                break;
        }
    }
}
