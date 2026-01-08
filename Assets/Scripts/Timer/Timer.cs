using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action<float> ValueChanged;
    public event Action Reseted;

    private MonoBehaviour _behaviour;
    private float _defaultValue = 10;
    private float _currentValue;

    private Coroutine _coroutine;

    public float CurrentValue => _currentValue;

    public Timer(MonoBehaviour behaviour)
    {
        _currentValue = _defaultValue;
        _behaviour = behaviour;
    }

    public void Start() 
    {
        if (_coroutine != null)
            Stop();

        _coroutine = _behaviour.StartCoroutine(Process());
    } 

    public void Stop() => _behaviour.StopCoroutine(_coroutine);
    public void Reset()
    {
        _currentValue = _defaultValue;
        Reseted?.Invoke();

        Stop();
        _coroutine = null;
        Start();
    }

    private IEnumerator Process()
    {
        while (_currentValue > 0)
        {
            _currentValue -= Time.deltaTime;
            ValueChanged?.Invoke(_currentValue);
            yield return null;
        }
    }
}
