using UnityEngine;

public class RollPin : Skill
{
    [SerializeField] GameObject _pin;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] Vector3 _speed;

    protected override void Activate()
    {
        _pin.SetActive(true);
        _pin.transform.position = transform.position;
        _rigidbody.velocity = _speed;
    }
}
