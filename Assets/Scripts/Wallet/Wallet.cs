using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<CurrencyType, int> CurrencyValueChanged;

    private Dictionary<CurrencyType, int> _valuesOfCurrencies = new Dictionary<CurrencyType, int>();

    public Wallet(int coinValue, int diamondValue, int foodValue)
    {
        _valuesOfCurrencies[CurrencyType.Coin] = coinValue;
        _valuesOfCurrencies[CurrencyType.Diamond] = diamondValue;
        _valuesOfCurrencies[CurrencyType.Food] = foodValue;
    }

    public Dictionary<CurrencyType, int> ValuesOfCurrencies => _valuesOfCurrencies;

    public int GetValue(CurrencyType type) => _valuesOfCurrencies[type];

    public void AddValue(CurrencyType type, int receivedValue)
    {
        if (receivedValue <= 0)
            return;

        int currentValue = _valuesOfCurrencies[type];
        int result = currentValue + receivedValue;

        _valuesOfCurrencies[type] = result;
        CurrencyValueChanged?.Invoke(type, result);
    }

    public void SubtractValue(CurrencyType type, int receivedValue)
    {
        int currentValue = _valuesOfCurrencies[type];

        if (receivedValue <= 0)
            return;

        if(IsEnoughCurrencyValue(type, receivedValue))
        {
            int result = currentValue - receivedValue;

            _valuesOfCurrencies[type] = result;
            CurrencyValueChanged?.Invoke(type, result);
        }
    }

    private bool IsEnoughCurrencyValue(CurrencyType type, int receivedValue)
    {
        int currentValue = _valuesOfCurrencies[type];

        if (receivedValue <= currentValue)
            return true;

        return false;
    }
}
