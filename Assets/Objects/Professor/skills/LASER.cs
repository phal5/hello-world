using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;

public class LASER : Skill
{
    [SerializeField] GameObject _left;
    [SerializeField] GameObject _right;
    [SerializeField] Transform _potato;

    override protected void Activate()
    {
        if(_potato.position.x < 0)
        {
            _left.SetActive(true);
        }
        else
        {
            _right.SetActive(true);
        }
    }
}
