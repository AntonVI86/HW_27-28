using UnityEngine;

public abstract class TimerView : MonoBehaviour
{
    public abstract void Initialize(Timer timer);
    public abstract void OnValueChanged(float value);
    public abstract void OnReseted();
}
