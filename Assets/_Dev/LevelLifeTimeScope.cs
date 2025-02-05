using Game.Map;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class LevelLifeTimeScope : LifetimeScope
    {
        [SerializeField]
        private Transform _upperLeftCorner;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_upperLeftCorner);
            builder.Register<MapManager>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}