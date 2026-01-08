using UnityEngine;

public abstract class TimerView : MonoBehaviour
{
    [SerializeField] protected TimerBehaviour Timer;

    private void Start()
    {
        Initialization();

        Timer.ValueChanged += OnValueChanged;
        Timer.Reseted += OnReseted;
    }

    public abstract void Initialization();
    public abstract void OnValueChanged(float value);
    public abstract void OnReseted();

    private void OnDestroy()
    {
        Timer.ValueChanged -= OnValueChanged;
        Timer.Reseted -= OnReseted;
    }
}
