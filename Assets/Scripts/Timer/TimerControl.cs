using UnityEngine;

public class TimerControl : MonoBehaviour
{
    [SerializeField] private TimerBehaviour _timer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _timer.StartProcess();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _timer.StopProcess();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _timer.ResetProcess();
    }
}
