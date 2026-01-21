using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Enemies
{   
    public class EnemyRegistrationService
    {
        private int _enemyCount = 0;

        private Dictionary<Enemy, Func<bool>> _addedEnemies = new();

        public int EnemyCount => _enemyCount;

        public void Register(Enemy enemy, Func<bool> DeathReason)
        {
            _addedEnemies.Add(enemy, DeathReason);
            _enemyCount++;
        }

        public void Update()
        {
            Debug.Log(_enemyCount);

            foreach (Func<bool> value in _addedEnemies.Values)
            {
                if (value.Invoke())
                {
                    _enemyCount--;
                    UnityEngine.Object.Destroy(_addedEnemies.FirstOrDefault(key => key.Value == value).Key.gameObject);
                    _addedEnemies.Remove(_addedEnemies.FirstOrDefault(key => key.Value == value).Key);
                }
            }
        }
    }
}
