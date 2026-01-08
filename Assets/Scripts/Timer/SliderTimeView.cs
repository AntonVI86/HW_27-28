using UnityEngine;
using UnityEngine.UI;

public class SliderTimeView : TimerView
{
    [SerializeField] private Slider _timeBar;

    private float _speed = 10;

    public override void Initialization()
    {
        _timeBar.gameObject.SetActive(true);
        _timeBar.maxValue = Timer.CurrentTime;
        _timeBar.value = Timer.CurrentTime;
    }

    public override void OnReseted()
    {
        _timeBar.value = Timer.CurrentTime;
    }

    public override void OnValueChanged(float value)
    {
        _timeBar.value = Mathf.Lerp(_timeBar.value, Timer.CurrentTime, _speed * Time.deltaTime);
    }
}
