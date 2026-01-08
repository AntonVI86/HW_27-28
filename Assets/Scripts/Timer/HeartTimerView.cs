using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeartTimerView : TimerView
{
    [SerializeField] private Image _heart;
    [SerializeField] private TMP_Text _timeVisual;

    private List<Image> _hearts = new List<Image>();

    public override void Initialization()
    {
        for (int i = 0; i < Timer.CurrentTime; i++)
        {
            Image newHeart = Instantiate(_heart, transform);
            _hearts.Add(newHeart);
        }
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
}
