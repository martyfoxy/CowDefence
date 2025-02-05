using System;
using Game;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.SpawnSystem
{
    public class EnemySpawner : ISpawner<EnemyView, EnemyData>
    {
        private ObjectPool<EnemyView> _pool;

        public EnemySpawner()
        {
            _pool = new ObjectPool<EnemyView>(SpawnNew, TakeFromPool, ReturnToPool, OnDestroy);
        }

        public EnemyView Spawn(SpawnPoint spawnPoint, EnemyData data)
        {
            var view = _pool.Get();
            view.transform.position = spawnPoint.Position;
            view.Setup(data);

            return view;
        }

        private EnemyView SpawnNew()
        {
            var prefab = Resources.Load<EnemyView>("Enemy");
            var instance = UnityEngine.Object.Instantiate(prefab);

            return instance;
        }

        private void TakeFromPool(EnemyView view)
        {
            view.gameObject.SetActive(true);
        }

        private void ReturnToPool(EnemyView view)
        {
            view.gameObject.SetActive(false);
        }

        private void OnDestroy(EnemyView view)
        {
            UnityEngine.Object.Destroy(view);
        }
    }
}