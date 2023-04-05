using System;
using UnityEngine;

namespace Game.Platforms.Data
{
    [CreateAssetMenu(fileName = "Cell", menuName = "GameData/Platforms", order = 0)]
    public class CellData : ScriptableObject
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private GameObject _platform;
        [SerializeField] private GameObject _wall;
        [Space]
        [SerializeField] private Cells[] _grid;
        
        public GameObject Parent => _parent;
        public GameObject Platform => _platform;
        public GameObject Wall => _wall;
        public Cell[][] Grid
        {
            get
            {
                var cells = new Cell[_grid.Length][];
                for (int i = 0; i < cells.Length; i++)
                {
                    cells[i] = _grid[i].Row;
                }

                return cells;
            }
        }
    }
    
    [Serializable]
    public struct Cells
    {
        public Cell[] Row;
    }
    
    [Serializable]
    public struct Cell
    {
        public TypeCell TypeCell;
    }

    public enum TypeCell
    {
        Null,
        Platform,
        Wall
    }

}