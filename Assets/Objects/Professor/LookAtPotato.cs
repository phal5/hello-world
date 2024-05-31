using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPotato : MonoBehaviour
{
    [SerializeField] Transform _this;
    [SerializeField] float _smoothTime = 0.1f;

    Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = 2 * transform.position - _this.position;
        transform.LookAt(Vector3.SmoothDamp(transform.forward + transform.position, target, ref _velocity, _smoothTime), Vector3.up);
    }
}
