using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightConveyer : MonoBehaviour
{
    public float _speed = 30;
    [Space(30f)]
    [SerializeField] GameObject _wheelClose;
    [SerializeField] GameObject _wheelFar;
    [SerializeField] GameObject _segments;
    [Space(30f)]
    [SerializeField] float _segmentLength = 0.454f;

    Vector3 _position;
    float _degreeRadianRatio = Mathf.PI / 180;
    float _dist;

    // Start is called before the first frame update
    void Start()
    {
        _position = _segments.transform.localPosition - _wheelClose.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = _speed * Time.deltaTime;
        Vector3 angles = Tile(_wheelFar.transform.localEulerAngles.x + rotation, 0, 18) * Vector3.right;
        _wheelFar.transform.localEulerAngles = angles;
        _wheelClose.transform.localEulerAngles = angles;
        MoveSegments(rotation);
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

        _segments.transform.localPosition = _dist * Vector3.forward + _position + _wheelClose.transform.localPosition;
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
