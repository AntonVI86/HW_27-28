using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private SourceCreator _sourceCreator;

    private int _minValue = 1;
    private int _maxValue = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _sourceCreator.GameWallet.AddValue(CurrencyType.Coin, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _sourceCreator.GameWallet.AddValue(CurrencyType.Diamond, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _sourceCreator.GameWallet.AddValue(CurrencyType.Food, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _sourceCreator.GameWallet.SubtractValue(CurrencyType.Coin, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _sourceCreator.GameWallet.SubtractValue(CurrencyType.Diamond, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _sourceCreator.GameWallet.SubtractValue(CurrencyType.Food, addedValue);
        }
    }
}
