using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Questions
{
    Question1,
    Question2,
    Question3,
    Question4
}
public class QuestionNode : Node
{
    public Node ModificationMusicA;
    public Node ModificationMusicB;

    public Questions myQuestion;

    public override void Execute(Player p)
    {
        if (ModificationMusicA == null) return;

        switch (myQuestion)
        {
            case Questions.Question1:
                //lo que tenga que hacer
                break;
            case Questions.Question2:
                // lo que tenga que hacer
                break;
            case Questions.Question3:
                // lo que tenga que hacer
                break;
            case Questions.Question4:
                // lo que tenga que hacer
                break;
        }
    }



}
