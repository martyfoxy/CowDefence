using Assets._Dev;
using Game.Map;
using Game.SpawnSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<EnemySpawner>(Lifetime.Singleton);
            builder.Register<GameController>(Lifetime.Singleton);
        }
    }
}