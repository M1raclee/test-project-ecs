using Code.ECS.Client.Systems;
using Leopotam.EcsLite;
using Zenject;

namespace Code.Bootstrap.Scene
{
    public class SceneSystemsInitializer
    {
        private readonly EcsSystems _ecsSystems;
        private readonly PlayerInitializeSystem _playerInitializeSystem;

        [Inject(Source = InjectSources.AnyParent)]
        public SceneSystemsInitializer(EcsSystems ecsSystems, PlayerInitializeSystem playerInitializeSystem)
        {
            _ecsSystems = ecsSystems;
            _playerInitializeSystem = playerInitializeSystem;

            Register();
        }

        private void Register() => 
            _ecsSystems.Add(_playerInitializeSystem);
    }
}