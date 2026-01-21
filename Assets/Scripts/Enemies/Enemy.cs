using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private bool _isDied;

        private DeathType _type;
        public bool IsDied => _isDied;
        public DeathType Type => _type;

        public void SetType(DeathType type) => _type = type;
    }
}
