using UnityEngine;

public class ServiceHandler : MonoBehaviour
{
    [SerializeField] private Service _service;

    private void Update()
    {
        _service.DestroyEnemyBy(OverageFilter);
        _service.DestroyEnemyBy(DeathFilter);
        _service.DestroyEnemyBy(TimeOutFilter);
    }

    private bool DeathFilter(Enemy enemy) 
    {
        if (enemy.Type == DeathTypes.Death)
            if (enemy.IsDeath)
                return true;

        return false;
    }

    private bool TimeOutFilter(Enemy enemy)
    {
        if (enemy.Type == DeathTypes.TimeIsOut)
            if(enemy.LifeTime <= 0)
                return true;

        return false;
    }

    private bool OverageFilter(Enemy enemy)
    {
        if (enemy.Type == DeathTypes.Overage)
            if (_service.IsOverage)
                return true;

        return false;
    }
}
