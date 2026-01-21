using System.Collections.Generic;
using UnityEngine;

public class WalletConsoleView : MonoBehaviour, IDisplayer
{
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.CurrencyValueChanged += OnCurrencyValueChanged;
    }

    public void OnCurrencyValueChanged(CurrencyType type, int value)
    {
        foreach (KeyValuePair<CurrencyType, int> item in _wallet.ValuesOfCurrencies)
        {
            Debug.Log(item.Key + " - " + item.Value);
        }
    }

    private void OnDestroy()
    {
        _wallet.CurrencyValueChanged -= OnCurrencyValueChanged;
    }
}
