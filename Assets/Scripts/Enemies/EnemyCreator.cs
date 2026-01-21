using System;
using UnityEngine;

namespace Enemies
{
    public class EnemyCreator : MonoBehaviour
    {
        public event Action<Enemy> Created;

        [SerializeField] private Transform _container;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private DeathType _type;

        public void Create()
        {
            Enemy enemy = Instantiate(_enemyPrefab, GetPosition(), Quaternion.identity, _container);
            enemy.SetType(_type);

            Created?.Invoke(enemy);
        }

        private Vector3 GetPosition()
        {
            float minXPosition = -10f;
            float maxXPosition = 10f;
            float minZPosition = -18f;
            float maxZPosition = 6f;

            return new Vector3(UnityEngine.Random.Range(minXPosition, maxXPosition), 0, UnityEngine.Random.Range(minZPosition, maxZPosition));
        }
    }
}
