using Code.Services.SceneContent;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Bootstrap.StateMachine
{
    public class LoadLevelState : IPayloadState<string>, IExitableState
    {
        private LazyInject<GameStateMachine> _stateMachine;
        private readonly ISceneContentService _sceneContentService;
        private readonly EcsSystems _systems;

        public LoadLevelState(LazyInject<GameStateMachine> stateMachine, ISceneContentService sceneContentService)
        {
            _stateMachine = stateMachine;
            _sceneContentService = sceneContentService;
        }

        public void Enter(string sceneName)
        {
            Debug.Log("Enter load level state");
            
            _sceneContentService.ContentLoadedEvent += SceneContentLoadedHandler;

            LoadGameScene(sceneName);
        }

        public void Exit() => 
            _sceneContentService.ContentLoadedEvent += SceneContentLoadedHandler;

        private void LoadGameScene(string sceneName) =>
            SceneManager.LoadSceneAsync(sceneName);

        private void SceneContentLoadedHandler() => 
            _stateMachine.Value.Enter<SystemsRegistrationState>();
    }
}