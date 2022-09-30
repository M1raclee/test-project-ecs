using Code.ECS.Client.Systems;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Bootstrap.StateMachine
{
    public class LoadLevelState : IPayloadState<string>
    {
        private LazyInject<GameStateMachine> _stateMachine;
        private readonly EcsSystems _systems;
        private readonly PlayerInitializeSystem _playerInitializeSystem;

        public LoadLevelState(LazyInject<GameStateMachine> stateMachine) => 
            _stateMachine = stateMachine;

        public void Enter(string sceneName)
        {
            Debug.Log("Enter load level state");
            
            LoadGameScene(sceneName);
        }

        private void LoadGameScene(string sceneName) =>
            SceneManager.LoadSceneAsync(sceneName).completed += GameSceneLoaded;

        private void GameSceneLoaded(AsyncOperation operation) =>
            _stateMachine.Value.Enter<SystemsRegistrationState>();
    }
}