using UnityEngine;

namespace Code.Bootstrap.StateMachine
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(GameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void Enter()
        {
            Debug.Log("Enter load level state");
            PrepareSystems();
            
            _stateMachine.Enter<GameLoopState>();
        }

        private void PrepareSystems()
        {
            
        }
    }
}