using UnityEngine;

public class TimerExample : MonoBehaviour
{
    private Timer _timer;

    [SerializeField] private TimerView[] _timerView;

    private void Awake()
    {
        _timer = new Timer(this, 10);

        foreach (TimerView view in _timerView)
            view.Initialize(_timer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _timer.Start();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _timer.Stop();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _timer.Reset();
    }
}
