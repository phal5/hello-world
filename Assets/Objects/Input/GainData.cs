using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainData : MonoBehaviour
{
    /*
    [SerializeField] ImportfromPort _port;

    [SerializeField] float _halfLife = 0;

    //2^(1/20) = 1.03526492384(halfLife = approx.20-23 secs at peak
    public float _halfLifeSum { get; private set; } = 0;
    [SerializeField] float _timer = 0;
    [SerializeField] int _count = 0;
    [SerializeField] bool _ready = false;

    bool _start = false;
    [SerializeField] int _triggerValue;
    */

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        _timer += Time.fixedDeltaTime;
        if (_ready)
        {
            _triggerValue = _port._value1 >> 1;
            _timer = 0;
            _ready = false;
        }

        if(_port._value1 < _triggerValue && _triggerValue != 0)
        {
            _triggerValue = _port._value1;
            _triggerValue >>= 1;
            _count++;
            _halfLifeSum += _timer;
            _halfLife = _halfLifeSum / _count;
            _timer = 0;
        }
        */
    }
}
