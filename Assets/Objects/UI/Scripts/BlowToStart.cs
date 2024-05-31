using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlowToStart : MonoBehaviour
{
    [SerializeField] int _sceneID;
    [SerializeField] float _startZ = 17.98f;
    [SerializeField] float _targetZ = 25;
    [SerializeField] Image _fillBar;
    [SerializeField] SpriteRenderer _black;
    [SerializeField] ImportfromPort _input;
    [SerializeField] float _speed = 0.3f;
    
    Vector3 _camStart;
    Color _transparent = new Color(1, 1, 1, 0);
    Color _zeroPointEight = new Color(1, 1, 1, 0.8f);
    [SerializeField]float _gauge;

    // Start is called before the first frame update
    void Start()
    {
        _camStart = Vector3.Scale(Camera.main.transform.position, Vector3.one - Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if(_input._input1 && _input._input2)
        {
            _gauge += _speed * Time.deltaTime;
        }

        if(_gauge > 1)
        {
            SceneManager.LoadScene(_sceneID);
        }
        _fillBar.fillAmount = _gauge;
        _black.color = Color.Lerp(_zeroPointEight, _transparent, _gauge);
        Camera.main.transform.position = _camStart + Mathf.Lerp(_targetZ, _startZ, 1 - _gauge * _gauge) * Vector3.forward;
    }
}
