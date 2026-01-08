using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _lifeTime = 3f;

    private DeathTypes _deathType;

    [SerializeField] private bool _isDeath = false;

    public DeathTypes Type => _deathType;
    public bool IsDeath => _isDeath;
    public float LifeTime => _lifeTime;

    private void Start()
    {
        StartCoroutine(CountDown());
    }

    public void SetType(DeathTypes type) => _deathType = type;

    private IEnumerator CountDown()
    {
        while(_lifeTime > 0)
        {
            _lifeTime -= Time.deltaTime;
            yield return null;
        }
    }
}
