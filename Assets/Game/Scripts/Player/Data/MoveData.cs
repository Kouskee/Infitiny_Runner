using UnityEngine;

namespace Game.Player.Data
{
    [CreateAssetMenu(fileName = "Move", menuName = "GameData/Player", order = 0)]
    public class MoveData : ScriptableObject
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField, Range(1, 100)] private int _speed;
        [SerializeField, Range(1, 100)] private int _resistance;
        [SerializeField, Range(1, 100)] private int _speedRotate;
        [SerializeField, Range(0.01f, 10)] private float _speedStopping;

        public GameObject GameObj => _gameObject;
        public int Speed =>_speed;
        public int SpeedRotate => _speedRotate;
        public float SpeedStopping => _speedStopping;
        public int Resistance => _resistance;
    }
}