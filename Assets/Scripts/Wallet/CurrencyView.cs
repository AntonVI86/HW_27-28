using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Image _picture;
    [SerializeField] private TMP_Text _value;

    private CurrencyType _type;

    public CurrencyType Type => _type;

    public void Initialize(CurrencyType type, Sprite sprite, int value)
    {
        _picture.sprite = sprite;
        _value.text = value.ToString();
        _type = type;
    }

    public void UpdateInfo(int value)
    {
        _value.text = value.ToString();
    }
}
