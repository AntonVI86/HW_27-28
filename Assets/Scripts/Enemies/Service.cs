using System;
using System.Collections.Generic;
using UnityEngine;

public class Service : MonoBehaviour
{
    public event Action<int> EnemyCountChanged;

    private List<Enemy> _enemies = new List<Enemy>();
    
    private int _enemiesCount;
    private int _maxEnemiesCount = 10;

    [SerializeField] private List<EnemyCreator> _enemyCreator;

    public int EnemiesCount => _enemiesCount;

    public bool IsOverage => _enemiesCount > _maxEnemiesCount;

    private void Awake()
    {
        foreach (EnemyCreator item in _enemyCreator)
        {
            item.Created += OnCreated;
        }

        EnemyCountChanged?.Invoke(_enemiesCount);
    }

    private void OnCreated(Enemy enemy)
    {
        _enemiesCount++;
        _enemies.Add(enemy);

        EnemyCountChanged?.Invoke(_enemiesCount);
    }

    public void DestroyEnemyBy(EnemyFilter enemyFilter)
    {
        List<Enemy> selectedEnemies = new List<Enemy>();

        foreach (Enemy enemy in _enemies)
            if (enemyFilter(enemy))
                selectedEnemies.Add(enemy);

        if (selectedEnemies.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, selectedEnemies.Count - 1);
            Destroy(selectedEnemies[index].gameObject);
            _enemies.Remove(selectedEnemies[index]);
            _enemiesCount--;

            EnemyCountChanged?.Invoke(_enemiesCount);
        }
    }
}
