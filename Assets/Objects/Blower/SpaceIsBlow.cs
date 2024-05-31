using UnityEngine;
using System.IO.Ports;

public class SpaceIsBlow : MonoBehaviour
{
    [Header("COM4")]
    [SerializeField] ImportfromPort _importer;

    byte[] _bytes = System.BitConverter.GetBytes(40.0f);
    SerialPort _port;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _importer._input1 = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _importer._input1 = false;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            _importer._input2 = true;
        }
        if(Input.GetKeyUp(KeyCode.RightShift))
        {
            _importer._input2 = false;
        }
    }
}
