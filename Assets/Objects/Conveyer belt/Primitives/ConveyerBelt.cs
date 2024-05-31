using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    [SerializeField] float _speed = 30;
    [Space(30f)]
    [SerializeField] GameObject _wheelClose;
    [SerializeField] GameObject _wheelFar;
    [SerializeField] GameObject[] _segments;
    [Space(30f)]
    [SerializeField] float _segmentLength = 0.454f;

    Rigidbody[] _segmentRigidbodies;
    Vector3[] _positions;
    float _degreeRadianRatio = Mathf.PI / 180;
    float _dist;
    int _length;

    // Start is called before the first frame update
    void Start()
    {
        _length = _segments.Length;
        _segmentRigidbodies = new Rigidbody[_length];
        _positions = new Vector3[_length];
        for(int i = 0; i < _length; ++i)
        {
            _segments[i].TryGetComponent<Rigidbody>(out _segmentRigidbodies[i]);
            _positions[i] = _segments[i].transform.localPosition - _wheelClose.transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = _speed * Time.deltaTime;
        Vector3 angles = Tile(_wheelFar.transform.localEulerAngles.x + rotation, 0, 18) * Vector3.right;
        _wheelFar.transform.localEulerAngles  = angles;
        _wheelClose.transform.localEulerAngles = angles;
        MoveSegments(rotation);

        foreach(Rigidbody rb in _segmentRigidbodies)
        {
            rb.velocity = transform.forward * _speed * _degreeRadianRatio;
        }
    }

    void MoveSegments(float rotation)
    {
        _dist += rotation * _degreeRadianRatio;
        while (_dist < -0.5 * _segmentLength)
        {
            _dist += _segmentLength;
        }
        while (_dist > 0.5 * _segmentLength)
        {
            _dist -= _segmentLength;
        }

        for (int i = 0; i < _length; ++i)
        {
            _segments[i].transform.localPosition = _dist * Vector3.forward + _positions[i] + _wheelClose.transform.localPosition;
        }
    }

    float Tile(float original, float min, float max)
    {
        if (max < min)
        {
            Debug.LogError("Max cannot be smaller than min");
            return 0;
        }
        float unit = max - min;
        while (original > max) original -= unit;
        while (original < max) original += unit;

        return original;
    }
}
