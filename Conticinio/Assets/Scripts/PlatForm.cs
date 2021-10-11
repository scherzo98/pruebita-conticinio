using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
    [SerializeField] Transform pos1, pos2;
    [SerializeField] float _speed;
    [SerializeField] Transform _starPos;

    Vector3 nextPos;

    private void Start()
    {
        nextPos = _starPos.position;
    }

    private void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, _speed * Time.deltaTime);
    }
}
