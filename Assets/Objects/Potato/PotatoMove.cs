using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMove : MonoBehaviour
{
    [SerializeField] ImportfromPort _signal;
    [SerializeField] Rigidbody _rigidBody;
    [Space(30f)]
    [SerializeField] float _coolDown;
    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [Space(30f)]
    [SerializeField] float _left;
    [SerializeField] float _right;

    float _preSwapY;
    float _timer;
    float _coolDownTimer;
    bool _swap;
    bool _lr = true;

    // Update is called once per frame
    void Update()
    {
        if (!_swap && _signal._input1 && !(_coolDownTimer < _coolDown))
        {
            _preSwapY = transform.position.y;
            _swap = true;
            _lr ^= true;
            _timer = 0;
            _coolDownTimer = 0;
            _rigidBody.useGravity = false;
        }

        if (_swap)
        {
            _timer += Time.deltaTime * _speed;
            if (_timer > 1)
            {
                _swap = false;
                _rigidBody.useGravity = true;
                _timer = 1;
            }
            SwapLane();
        }
        else if (_coolDownTimer <= _coolDown && !_signal._input1)
        {
            _coolDownTimer += Time.deltaTime;
        }
    }

    void SwapLane()
    {
        transform.position =
            Vector3.up * (_preSwapY + (2 * _timer - _timer * _timer) * _jump) +
            Vector3.forward * transform.position.z +
            Vector3.right * LerpPoints(_left, _right, (Whirl(_timer) - 0.5f) * (_lr ? -1 : 1) + 0.5f);
    }

    float Whirl(float x)
    {
        x = x * x * 3 - 1.91553344619f;

        float y = x * x - 3;
        y = y * x + 1;
        y = y * x + 1.5f;
        return (y * x + 3.9080548297f) * 0.22807264022f;
    }

    float Jump(float x)
    {
        return x;
    }

    float LerpPoints(float a, float b, float t)
    {
        return t * b + (1 - t) * a;
    }
}
