using Code.ECS.Client.Systems;
using Code.ECS.Server.Systems;
using Code.Services.SceneContent;
using Leopotam.EcsLite;
using Zenject;

namespace Code.Bootstrap.StateMachine
{
    public class SystemsRegistrationState : IEnterableState
    {
        private readonly EcsSystems _systems;
        private readonly PlayerInitializeSystem _playerInitializeSystem;
        private readonly PlayerInputSystem _playerInputSystem;
        private readonly GameObjectMovementSystem _gameObjectMovementSystem;
        private readonly VelocityMovementSystem _velocityMovementSystem;
        private readonly CharacterMovementSystem _characterMovementSystem;
        private readonly PlayerCharacterBindSystem _playerCharacterBindSystem;
        private readonly GameplayButtonInitializeSystem _gameplayButtonInitializeSystem;
        private readonly GameplayButtonsBindSystem _gameplayButtonsBindSystem;
        private readonly ButtonsInteractorSystem _buttonsInteractorSystem;
        private readonly ISceneContentService _sceneContentService;
        private readonly LazyInject<GameStateMachine> _stateMachine;

        public SystemsRegistrationState(LazyInject<GameStateMachine> stateMachine, EcsSystems systems,
            ISceneContentService sceneContentService, PlayerInitializeSystem playerInitializeSystem,
            PlayerInputSystem playerInputSystem, GameObjectMovementSystem gameObjectMovementSystem,
            VelocityMovementSystem velocityMovementSystem, CharacterMovementSystem characterMovementSystem,
            PlayerCharacterBindSystem playerCharacterBindSystem, GameplayButtonInitializeSystem gameplayButtonInitializeSystem,
            GameplayButtonsBindSystem gameplayButtonsBindSystem, ButtonsInteractorSystem buttonsInteractorSystem)
        {
            _stateMachine = stateMachine;
            _systems = systems;
            _sceneContentService = sceneContentService;
            _playerInitializeSystem = playerInitializeSystem;
            _playerInputSystem = playerInputSystem;
            _gameObjectMovementSystem = gameObjectMovementSystem;
            _velocityMovementSystem = velocityMovementSystem;
            _characterMovementSystem = characterMovementSystem;
            _playerCharacterBindSystem = playerCharacterBindSystem;
            _gameplayButtonInitializeSystem = gameplayButtonInitializeSystem;
            _gameplayButtonsBindSystem = gameplayButtonsBindSystem;
            _buttonsInteractorSystem = buttonsInteractorSystem;
        }

        public void Enter()
        {
            ApplySceneContent();
            PrepareSystems();

            _systems.Init();
            _stateMachine.Value.Enter<GameLoopState>();
        }

        private void ApplySceneContent()
        {
            _playerCharacterBindSystem.SetupPlayerObject(_sceneContentService.GameSceneContent.Player);
            _gameplayButtonsBindSystem.SetupButtonsObject(_sceneContentService.GameSceneContent.Buttons);
        }

        private void PrepareSystems()
        {
            PreparePlayerSystems();
            PrepareEnvironmentSystems();
        }

        private void PreparePlayerSystems()
        {
            _systems.Add(_playerInputSystem);
            _systems.Add(_gameObjectMovementSystem);
            _systems.Add(_playerInitializeSystem);
            _systems.Add(_characterMovementSystem);
            _systems.Add(_playerCharacterBindSystem);
            _systems.Add(_velocityMovementSystem);
        }

        private void PrepareEnvironmentSystems()
        {
            _systems.Add(_gameplayButtonInitializeSystem);
            _systems.Add(_gameplayButtonsBindSystem);
            _systems.Add(_buttonsInteractorSystem);
        }
    }
}