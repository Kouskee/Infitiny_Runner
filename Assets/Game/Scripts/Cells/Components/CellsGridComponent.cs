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
        
        public Cell GetCell(int x, int y, int xNext)
        {
            var cell = new Cell();
            
            for (int i = x; i <= xNext; i++)
            {
                if (Contains(i, y))
                {
                    if (Grid[i][y].TypeCell == TypeCell.Wall) return Grid[i][y];
                    cell = Grid[i][y];
                }
                else
                    cell = new Cell { TypeCell = TypeCell.Null };
            }

            return cell;
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