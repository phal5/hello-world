using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using TMPro;
using UnityEngine;

public class ThrowKnife : Skill
{
    [SerializeField] GameObject _knife;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] Transform _potato;
    [SerializeField] Vector3 _offset;
    [SerializeField] Vector3 _speed;
    [SerializeField] float _rotationSpeed;

    protected override void Activate()
    {
        _knife.SetActive(true);
        _knife.transform.position = Vector3.Scale(_potato.position, Vector3.one - Vector3.up) + _offset;
        _rigidbody.velocity = _speed;
        _rigidbody.angularVelocity = Vector3.right * _rotationSpeed;
    }
}
