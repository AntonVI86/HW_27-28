using System.Collections.Generic;
using UnityEngine;

public class WalletConsoleView : MonoBehaviour, IDisplayer
{
    [SerializeField] private SourceCreator _sourceCreator;

    public void Start()
    {
        _sourceCreator.GameWallet.CurrencyValueChanged += OnCurrencyValueChanged;
    }

    public void OnCurrencyValueChanged(CurrencyType type, int value)
    {
        foreach (KeyValuePair<CurrencyType, int> item in _sourceCreator.GameWallet.ValueOfCurrency)
        {
            Debug.Log(item.Key + " - " + item.Value);
        }
    }

    private void OnDestroy()
    {
        _sourceCreator.GameWallet.CurrencyValueChanged -= OnCurrencyValueChanged;
    }
}
