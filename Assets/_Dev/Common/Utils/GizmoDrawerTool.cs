#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Common.Utils
{
    public class GizmoDrawerTool : MonoBehaviour
    {
        public static GizmoDrawerTool Instance { get; private set; }

        private readonly List<Tuple<Vector3, Vector3, Color>> _cubes = new List<Tuple<Vector3, Vector3, Color>>();

        private void Awake()
        {
            Instance = this;
        }

        public void DrawCube(Vector3 pos, Vector3 size, Color color)
        {
            _cubes.Add(new Tuple<Vector3, Vector3, Color>(pos, size, color));
        }

        public void ClearCubes()
        {
            _cubes.Clear();
        }

        private void OnDrawGizmos()
        {
            foreach (var cube in _cubes)
            {
                Gizmos.color = cube.Item3;
                Gizmos.DrawCube(cube.Item1, cube.Item2);
            }
        }
    }
}
#endif