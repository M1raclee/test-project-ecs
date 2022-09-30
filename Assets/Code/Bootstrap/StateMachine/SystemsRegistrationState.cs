using Code.ECS.Client.Systems;
using Code.Services.SceneContent;
using Leopotam.EcsLite;
using Zenject;

namespace Code.Bootstrap.StateMachine
{
    public class SystemsRegistrationState : IEnterableState
    {
        private readonly EcsSystems _systems;
        private readonly PlayerInitializeSystem _playerInitializeSystem;
        private readonly ISceneContentService _sceneContentService;
        private readonly LazyInject<GameStateMachine> _stateMachine;

        public SystemsRegistrationState(LazyInject<GameStateMachine> stateMachine, EcsSystems systems,
            PlayerInitializeSystem playerInitializeSystem, ISceneContentService sceneContentService)
        {
            _stateMachine = stateMachine;
            _systems = systems;
            _playerInitializeSystem = playerInitializeSystem;
            _sceneContentService = sceneContentService;
        }

        public void Enter()
        {
            ApplySceneContent();
            PrepareSystems();

            _systems.Init();
            _stateMachine.Value.Enter<GameLoopState>();
        }

        private void ApplySceneContent() =>
            _playerInitializeSystem.SetupPlayerObject(_sceneContentService.GameSceneContent.Player);

        private void PrepareSystems() =>
            _systems.Add(_playerInitializeSystem);
    }
}