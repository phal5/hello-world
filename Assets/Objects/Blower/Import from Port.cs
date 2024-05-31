using System;
using UnityEngine;

public class ImportfromPort : MonoBehaviour
{
    [SerializeField] NamedPipeClient1 _client;
    [SerializeField] KeyCode _resetKey = KeyCode.Alpha1;
    [SerializeField] int _bufferLength = 10;
    [SerializeField] int _increaseMargin = 3;
    [SerializeField] int _decreaseMargin = 1;
    public bool _input1 = false;
    public bool _input2 = false;

    float _baseValueF1 = 0;
    float _baseValueF2 = 0;
    float _initTimer = 3;
    float _timer;
    int _thirdBufferSize;
    int _bV1;
    int _bV2;
    [SerializeField]int _latterSum = 0;
    [SerializeField] int _value1 = 0;
    [SerializeField] int _value2 = 0;
    [SerializeField]bool _takingIn = true;

    int[] _buffer1;
    int[] _buffer2;
    int _bufferIndex = 0;
    [SerializeField]int _expectation = 0;

    // Start is called before the first frame update
    void Start()
    {
        _thirdBufferSize = _bufferLength / 3;
        _buffer1 = new int[_bufferLength];
        _buffer2 = new int[_bufferLength];

        _timer = _initTimer;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_resetKey))
        {
            _takingIn = true;
            _timer = _initTimer;
            _value1 = 0;
            _value2 = 0;
            _baseValueF1 = 0;
            _baseValueF2 = 0;
            _expectation = 0;
            _latterSum = 0;
            _input1 = false;
            _input2 = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_takingIn)
        {
            _baseValueF1 += Time.deltaTime * _client._message1;
            _baseValueF2 += Time.deltaTime * _client._message2;
            _timer -= Time.deltaTime;

            if (_timer < 0)
            {
                _baseValueF1 /= _initTimer;
                _baseValueF2 /= _initTimer;
                _takingIn = false;
                _bV1 = Convert.ToInt32(_baseValueF1);
                _bV2 = Convert.ToInt32(_baseValueF2);
            }
        }

        else
        {
            _value1 = _client._message1 - _bV1;
            _value2 = _client._message2 - _bV2;
            if (++_bufferIndex >= _bufferLength)
            {
                _bufferIndex = 0;
            }

            if (CountRounds._switch)
            {
                SetInputs(ref _buffer1, ref _input2, _value1);
                SetInputs(ref _buffer2, ref _input1, _value2);
            }
            else
            {
                SetInputs(ref _buffer1, ref _input1, _value1);
                SetInputs(ref _buffer2, ref _input2, _value2);
            }
        }
    }

    void SetInputs(ref int[] buffer, ref bool input, int value)
    {
        buffer[_bufferIndex] = value;
        _latterSum = SumOfBufferBefore(buffer, _bufferIndex);

        //median + (median - former) = a + (da * dt) = prediction
        //could optimize through UpdateSum, but had no time
        _expectation =
            SumOfBufferBefore(buffer, _bufferIndex - _thirdBufferSize) * 2 -
            SumOfBufferBefore(buffer, _bufferIndex - 2 * _thirdBufferSize);

        if (input)
        {
            if (_expectation - _decreaseMargin > _latterSum)
            {
                input = false;
                Debug.Log("Nup");
            }
        }
        else
        {
            if (_expectation + _increaseMargin < _latterSum)
            {
                input = true;
                Debug.Log("Yup");
            }
        }
    }

    int Indexify(int index)
    {
        return (index < 0 ? index + _bufferLength : (index < _bufferLength ? index : index - _bufferLength));
    }

    void UpdateSum(ref int sum, int[] buffer, int push)
    {
        sum += buffer[Indexify(push)] - buffer[Indexify(push - _thirdBufferSize)];
    }

    int SumOfBufferBefore(int[] buffer, int index)
    {
        int sum = 0;
        for(int i = 0;  i < _thirdBufferSize; i++)
        {
            sum += buffer[Indexify(index - i)];
        }
        return sum;
    }
}
