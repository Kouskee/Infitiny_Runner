using Game.Platforms.Data;

namespace Game.Platforms
{
    public class CellsGridComponent
    {
        public Cell[][] Grid { get; private set; }
        
        public CellsGridComponent(Cell[][] grid)
        {
            Grid = grid;
        }

        public void DestroyGrid()
        {
            Grid = new Cell[0][];
        }
        
        public Cell GetCell(int y, int x)
        {
            return Contains(x, y) ? Grid[x][y] : new Cell {TypeCell = TypeCell.Null};
        }
        
        private bool Contains(int x, int y)
        {
            if (x <= Grid.GetUpperBound(0) && x >= 0)
                if (y <= Grid[x].GetUpperBound(0) && y >= 0)
                    return true;
            
            return false;
        }
    }
}