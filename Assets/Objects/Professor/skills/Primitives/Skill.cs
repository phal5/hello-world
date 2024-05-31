using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Skill : MonoBehaviour
{
    [SerializeField] Image _icon;
    [SerializeField] string _animID;
    [SerializeField] float _coolDown;
    [SerializeField] float _delay;
    public static float _coolDownMultiplier = 1;

    float _timer;
    float _delayTimer;
    float _invCooldown;
    bool _useSkill = false;

    private void Start()
    {
        _timer = _coolDown;
        _invCooldown = 1 / _coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _icon.fillAmount = _timer * _invCooldown / _coolDownMultiplier;
        if (_useSkill)
        {
            _delayTimer += Time.deltaTime;
            if(_delayTimer > _delay)
            {
                _useSkill = false;
                _delayTimer = 0;
                Activate();
            }
        }
    }

    public bool Call(out string _id)
    {
        _id = _animID;
        if(_timer > _coolDown * _coolDownMultiplier)
        {
            _timer = 0;
            _useSkill = true;
            return true;
        }
        return false;
    }

    protected virtual void Activate() { }
}
