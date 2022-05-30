using UnityEngine;
using Abstractions;

namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        [SerializeField] private GameObject _selected;

        private float _health = 1000;

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab,
                new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                Quaternion.identity, _unitsParent);
        }

        public void UnsetSelected()
        {
            _selected.SetActive(false);
        }

        public void SetSelected()
        {
            _selected.SetActive(true);
        }
    }
}