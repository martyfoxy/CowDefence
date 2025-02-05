using Game.Common;
using Game.Common.Utils;
using UnityEngine;

namespace Game.Map
{
    public class Map
    {
        public const int CellSize = 2;

        public int Cols { get; private set; }
        public int Rows { get; private set; }

        private Vector3 _upperLeftCorner;
        private Cell[,] _cells;

        public Map(Vector3 upperLeftCorner, int cols, int rows)
        {
            Cols = cols;
            Rows = rows;
            _upperLeftCorner = upperLeftCorner;

            Generate();
        }

        public Cell Get(int row, int col)
        {
            if (row < 0 || row > Rows - 1)
            {
                Debug.LogError("Wrong cell row");
                return default;
            }

            if (col< 0 || col > Cols - 1)
            {
                Debug.LogError("Wrong cell column");
                return default;
            }

            return _cells[row, col];
        }

        public Cell[,] GetAll()
        {
            return _cells;
        }

        private void Generate()
        {
            _cells = new Cell[Rows, Cols];
            GizmoDrawerTool.Instance.ClearCubes();

            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Cols; col++) 
                {
                    var pos = _upperLeftCorner + new Vector3(
                        CellSize * 0.5f + CellSize * col,
                        _upperLeftCorner.y,
                        -CellSize * 0.5f - CellSize * row);

                    _cells[row, col] = new Cell(row, col, pos);
                    GizmoDrawerTool.Instance.DrawCube(pos, new Vector3(CellSize, 0.5f, CellSize), Color.red);
                }
            }
        }


    }

    public struct Cell
    {
        public int Col { get; }
        public int Row { get; }
        public Vector3 WorldPosition { get; }

        public Parameter<bool> IsOccupied;

        public Cell(int row, int col, Vector3 worldPos)
        {
            Row = row;
            Col = col;
            WorldPosition = worldPos;
            IsOccupied = new Parameter<bool>("IsOccupied");
        }
    }
}