using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocalY : MonoBehaviour
{
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _speed * 360 * Time.deltaTime, 0);
    }
}
