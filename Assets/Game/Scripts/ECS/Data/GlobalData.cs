using Game.Platforms.Data;
using Game.Player.Data;
using UnityEngine;

namespace Game.ECS
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameData/Global", order = 0)]
    public class GlobalData : ScriptableObject
    {
        [SerializeField] private MoveData _moveData;
        [SerializeField] private CellData _cellData;

        public MoveData MoveData => _moveData;
        public CellData CellData => _cellData;
    }
}