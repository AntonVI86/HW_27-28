using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeartTimerView : TimerView
{
    private Timer _timer;

    private List<Image> _hearts = new List<Image>();

    [SerializeField] private Image _heart;
    [SerializeField] private TMP_Text _timeVisual;

    public override void Initialize(Timer timer)
    {
        _timer = timer;

        for (int i = 0; i < _timer.CurrentValue; i++)
        {
            Image newHeart = Instantiate(_heart, transform);
            _hearts.Add(newHeart);
        }

        _timer.ValueChanged += OnValueChanged;
        _timer.Reseted += OnReseted;
    }

    public override void OnReseted()
    {
        foreach (Image item in _hearts)
        {
            item.gameObject.SetActive(true);
        }
    }

    public override void OnValueChanged(float value)
    {
        _timeVisual.text = value.ToString("0.0");

        if(_hearts.Count > Mathf.CeilToInt(value))
        {
            _hearts[Mathf.CeilToInt(value)].gameObject.SetActive(false);
        }   
    }

    public void OnDestroy()
    {
        _timer.ValueChanged -= OnValueChanged;
        _timer.Reseted -= OnReseted;
    }
}
