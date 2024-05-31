using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlowToRestart : MonoBehaviour
{
    [SerializeField] int _sceneID;
    [SerializeField] ImportfromPort _input;

    // Update is called once per frame
    void Update()
    {
        if (_input._input1 || _input._input2)
        {
            SceneManager.LoadScene(_sceneID);
        }
    }
}
