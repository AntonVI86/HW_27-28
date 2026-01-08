using UnityEngine;

public class SourceCreator : MonoBehaviour
{
    private Wallet _wallet;

    public Wallet GameWallet => _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }
}
