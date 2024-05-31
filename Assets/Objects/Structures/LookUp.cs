using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUp : MonoBehaviour
{
    Vector3 _forward;
    // Start is called before the first frame update
    void Start()
    {
        _forward = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(_forward, Vector3.up);
    }
}
