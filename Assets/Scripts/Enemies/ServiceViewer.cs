using TMPro;
using UnityEngine;

public class ServiceViewer : MonoBehaviour
{
    [SerializeField] private Service _service;
    [SerializeField] private TMP_Text _enemyCount;

    private void Awake()
    {
        _service.EnemyCountChanged += OnEnemyCountChanged;
    }

    private void OnEnemyCountChanged(int count)
    {
        _enemyCount.text = "Врагов на сцене " + _service.EnemiesCount.ToString();
    }

    private void OnDestroy()
    {
        _service.EnemyCountChanged -= OnEnemyCountChanged;
    }
}
