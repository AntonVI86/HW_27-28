using System;
using UnityEngine;

public class TimerBehaviour : MonoBehaviour
{
    public event Action<float> ValueChanged
    {
        add => _timer.ValueChanged += value;
        remove => _timer.ValueChanged -= value;
    }

    public event Action Reseted
    {
        add => _timer.Reseted += value;
        remove => _timer.Reseted -= value;
    }

    private Timer _timer;

    public float CurrentTime => _timer.CurrentValue;

    private void Awake()
    {
        _timer = new Timer(this);
    }

    public void StartProcess() => _timer.Start();
    public void StopProcess() => _timer.Stop();
    public void ResetProcess() => _timer.Reset();
}
