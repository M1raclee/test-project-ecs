using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Bootstrap.StateMachine
{
    public class LoadLevelState : IPayloadState<string>
    {
        private LazyInject<GameStateMachine> _stateMachine;

        public LoadLevelState(LazyInject<GameStateMachine> stateMachine) =>
            _stateMachine = stateMachine;

        public void Enter(string sceneName)
        {
            Debug.Log("Enter load level state");

            PrepareSystems();
            LoadGameScene(sceneName);
        }

        private void PrepareSystems() { }

        private void LoadGameScene(string sceneName) =>
            SceneManager.LoadSceneAsync(sceneName).completed += GameSceneLoaded;

        private void GameSceneLoaded(AsyncOperation operation) =>
            _stateMachine.Value.Enter<GameLoopState>();
    }
}