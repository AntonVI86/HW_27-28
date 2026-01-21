using System.Collections.Generic;
using UnityEngine;

public class WalletUIView : MonoBehaviour, IDisplayer
{
    private Wallet _wallet;

    private List<CurrencyView> _currencyViews = new List<CurrencyView>();

    [SerializeField] private CurrencyView _currencyViewPrefab;
    [SerializeField] private Sprite[] _icon;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        CreateView();
        _wallet.CurrencyValueChanged += OnCurrencyValueChanged;
    }

    public void OnCurrencyValueChanged(CurrencyType type, int value)
    {
        foreach (CurrencyView item in _currencyViews)
        {
            if(type == item.Type)
                item.UpdateInfo(value);
        }
    }

    private void CreateView()
    {
        int index = 0;
        CurrencyType type = 0;

        foreach (KeyValuePair<CurrencyType, int> item in _wallet.ValuesOfCurrencies)
        {
            CurrencyView view = Instantiate(_currencyViewPrefab, transform);
            view.Initialize(type,_icon[index], item.Value);
            _currencyViews.Add(view);

            index++;
            type++;
        }
    }

    private void OnDestroy()
    {
        _wallet.CurrencyValueChanged -= OnCurrencyValueChanged;
    }
}
