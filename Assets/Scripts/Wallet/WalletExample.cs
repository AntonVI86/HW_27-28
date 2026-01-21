using UnityEngine;

public class WalletExample : MonoBehaviour
{
    private Wallet _wallet;

    private int _minValue = 1;
    private int _maxValue = 5;

    [SerializeField] private WalletUIView _walletUIView;
    [SerializeField] private WalletConsoleView _walletConsoleView;

    private void Awake()
    {
        _wallet = new Wallet(1,10,5);

        _walletConsoleView.Initialize(_wallet);
        _walletUIView.Initialize(_wallet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.AddValue(CurrencyType.Coin, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.AddValue(CurrencyType.Diamond, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.AddValue(CurrencyType.Food, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.SubtractValue(CurrencyType.Coin, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.SubtractValue(CurrencyType.Diamond, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.SubtractValue(CurrencyType.Food, addedValue);
        }
    }
}
