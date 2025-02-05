using System.Collections;
using System.Collections.Generic;
using Assets._Dev.Map;
using UnityEngine;
using VContainer.Unity;

namespace Game.Map
{
    public class MapManager : IInitializable
    {
        private readonly Transform _upperLeft;
        private Map _map;

        private List<CellView> _cellsViews;

        public MapManager(Transform upperLeftPos)
        {
            _upperLeft = upperLeftPos;
        }

        public void Initialize()
        {
            _cellsViews = new List<CellView>();
            _map = new Map(_upperLeft.position, 14, 12);

            var cells = _map.GetAll();
            var cellPrefab = Resources.Load<CellView>("Cell");

            foreach (var cell in cells)
            {
                var instance = Object.Instantiate(cellPrefab, cell.WorldPosition, Quaternion.identity);
                instance.transform.SetParent(_upperLeft);
                instance.name = $"{cell.Col}_{cell.Row}";
                _cellsViews.Add(instance);
            }

            Debug.Log("Map created");
        }
    }
}