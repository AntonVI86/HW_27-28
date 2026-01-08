using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<CurrencyType, int> CurrencyValueChanged; 

    private Dictionary<CurrencyType, int> _valueOfCurrency = new Dictionary<CurrencyType, int>()
    {
        {CurrencyType.Coin, 0 },
        {CurrencyType.Diamond, 0 },
        {CurrencyType.Food, 0 }
    };

    public Dictionary<CurrencyType, int> ValueOfCurrency => _valueOfCurrency;

    public int GetValue(CurrencyType type) => _valueOfCurrency[type];
    public void AddValue(CurrencyType type, int receivedValue)
    {
        if (receivedValue <= 0)
            return;

        int currentValue = _valueOfCurrency[type];
        int result = currentValue + receivedValue;

        _valueOfCurrency[type] = result;
        CurrencyValueChanged?.Invoke(type, result);
    }

    public void SubtractValue(CurrencyType type, int receivedValue)
    {
        int currentValue = _valueOfCurrency[type];

        if (receivedValue > currentValue)
            return;

        int result = currentValue - receivedValue;

        _valueOfCurrency[type] = result;
        CurrencyValueChanged?.Invoke(type, result);
    }
}
