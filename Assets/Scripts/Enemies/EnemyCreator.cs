using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCreator : MonoBehaviour
{
    public event Action<Enemy> Created;

    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private DeathTypes _deathType;

    private Button _enemyCreator;
    private DeathTypeAssigner _assigner;

    private void Awake()
    {
        _enemyCreator = GetComponent<Button>();
        _enemyCreator.onClick.AddListener(OnCreateEnemy);

        _assigner = new DeathTypeAssigner(AssignType);
    }

    public void OnCreateEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, GetPosition(), Quaternion.identity, _container);
        _assigner?.Invoke(enemy);

        Created?.Invoke(enemy);
    }

    private void AssignType(Enemy enemy) => enemy.SetType(_deathType);

    private Vector3 GetPosition()
    {
        float minXPosition = -10f;
        float maxXPosition = 10f;
        float minZPosition = -18f;
        float maxZPosition = 6f;

        return new Vector3(UnityEngine.Random.Range(minXPosition, maxXPosition), 0, UnityEngine.Random.Range(minZPosition, maxZPosition));
    }


    private void OnDestroy()
    {
        _enemyCreator.onClick.RemoveListener(OnCreateEnemy);
    }
}
