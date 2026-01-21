using UnityEngine;
using UnityEngine.UI;

public class SliderTimeView : TimerView
{
    private Timer _timer;

    private float _speed = 10;

    [SerializeField] private Slider _timeBar;

    public override void Initialize(Timer timer)
    {
        _timer = timer;

        _timeBar.gameObject.SetActive(true);
        _timeBar.maxValue = _timer.CurrentValue;
        _timeBar.value = _timer.CurrentValue;

        _timer.ValueChanged += OnValueChanged;
        _timer.Reseted += OnReseted;
    }

    public override void OnReseted()
    {
        _timeBar.value = _timer.CurrentValue;
    }

    public override void OnValueChanged(float value)
    {
        _timeBar.value = Mathf.Lerp(_timeBar.value, _timer.CurrentValue, _speed * Time.deltaTime);
    }

    public void OnDestroy()
    {
        _timer.ValueChanged -= OnValueChanged;
        _timer.Reseted -= OnReseted;
    }
}
