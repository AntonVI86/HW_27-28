using UnityEngine;

namespace Enemies
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private EnemyCreator[] _enemyCreators;

        private EnemyRegistrationService _service;

        private void Awake()
        {
            _service = new EnemyRegistrationService();

            foreach (EnemyCreator creator in _enemyCreators)
                creator.Created += OnCreated;
        }

        private void Update() =>
            _service.Update();

        public void OnCreated(Enemy enemy)
        {
            switch (enemy.Type)
            {
                case DeathType.BoolDeath:
                    _service.Register(enemy, () =>
                    {
                        return enemy.IsDied;
                    });
                    break;

                case DeathType.TimeIsOut:
                    float spawnTime = Time.time;

                    _service.Register(enemy, () =>
                    {
                        return Time.time - spawnTime > 5f;
                    });
                    break;

                case DeathType.Overage:
                    _service.Register(enemy, () =>
                    {
                        return _service.EnemyCount > 10;
                    });
                    break;
            }
        }
    }
}
