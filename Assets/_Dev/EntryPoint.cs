using Game.SpawnSystem;
using UnityEditor;
using UnityEngine;
using VContainer;

namespace Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _enemySpawnPoint;

        private EnemySpawner _enemySpawner;

        private void Awake()
        {
            return;
            _enemySpawner = new EnemySpawner();

            _enemySpawner.Spawn(
                new SpawnPoint
                {
                    Position = _enemySpawnPoint.position
                },
                new EnemyData
                {
                    Speed = 5,
                    Level = 1
                });
        }
    }
}