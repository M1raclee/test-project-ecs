using Code.ECS.Client.Systems;
using Code.ECS.Client.Systems.Binding;
using Code.ECS.Client.Systems.Movement;
using Code.ECS.Server.Systems;
using Code.ECS.Server.Systems.Initialization;
using Code.ECS.Server.Systems.Movement;
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
        private readonly MovementSystem _movementSystem;
        private readonly CharacterMovementSystem _characterMovementSystem;
        private readonly PlayerCharacterBindSystem _playerCharacterBindSystem;
        private readonly ButtonInitializeSystem _buttonInitializeSystem;
        private readonly ButtonsBindSystem _buttonsBindSystem;
        private readonly ButtonsInteractorSystem _buttonsInteractorSystem;
        private readonly DoorsInitializeSystem _doorsInitializeSystem;
        private readonly DoorsBindSystem _doorsBindSystem;
        private readonly DoorMovementSystem _doorMovementSystem;
        private readonly ISceneContentService _sceneContentService;
        private readonly LazyInject<GameStateMachine> _stateMachine;

        public SystemsRegistrationState(LazyInject<GameStateMachine> stateMachine, EcsSystems systems,
            ISceneContentService sceneContentService, PlayerInitializeSystem playerInitializeSystem,
            PlayerInputSystem playerInputSystem, GameObjectMovementSystem gameObjectMovementSystem,
            MovementSystem movementSystem, CharacterMovementSystem characterMovementSystem,
            PlayerCharacterBindSystem playerCharacterBindSystem, ButtonInitializeSystem buttonInitializeSystem,
            ButtonsBindSystem buttonsBindSystem, ButtonsInteractorSystem buttonsInteractorSystem,
            DoorsInitializeSystem doorsInitializeSystem, DoorsBindSystem doorsBindSystem,
            DoorMovementSystem doorMovementSystem)
        {
            _stateMachine = stateMachine;
            _systems = systems;
            _sceneContentService = sceneContentService;
            _playerInitializeSystem = playerInitializeSystem;
            _playerInputSystem = playerInputSystem;
            _gameObjectMovementSystem = gameObjectMovementSystem;
            _movementSystem = movementSystem;
            _characterMovementSystem = characterMovementSystem;
            _playerCharacterBindSystem = playerCharacterBindSystem;
            _buttonInitializeSystem = buttonInitializeSystem;
            _buttonsBindSystem = buttonsBindSystem;
            _buttonsInteractorSystem = buttonsInteractorSystem;
            _doorsInitializeSystem = doorsInitializeSystem;
            _doorsBindSystem = doorsBindSystem;
            _doorMovementSystem = doorMovementSystem;
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
            _buttonsBindSystem.SetupButtonsObject(_sceneContentService.GameSceneContent.Buttons);
            _doorsBindSystem.SetupDoorsObject(_sceneContentService.GameSceneContent.Doors);
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
            _systems.Add(_movementSystem);
        }

        private void PrepareEnvironmentSystems()
        {
            PrepareButtonSystems();
            PrepareDoorsSystem();
        }

        private void PrepareDoorsSystem()
        {
            _systems.Add(_doorsInitializeSystem);
            _systems.Add(_doorsBindSystem);
            _systems.Add(_buttonsInteractorSystem);
        }

        private void PrepareButtonSystems()
        {
            _systems.Add(_buttonInitializeSystem);
            _systems.Add(_buttonsBindSystem);
            _systems.Add(_doorMovementSystem);
        }
    }
}