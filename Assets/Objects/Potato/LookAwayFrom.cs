using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAwayFrom : MonoBehaviour
{
    [SerializeField] Transform _this;
    [SerializeField] float _lookThisMuchUp;

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Vector3.Scale(_this.position, Vector3.one - Vector3.up) + Vector3.up * (transform.position.y - _lookThisMuchUp);
        transform.LookAt(target, Vector3.up);
    }
}
