using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] Transform _this;
    Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _this.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _offset + _this.position;
    }
}
