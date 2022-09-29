using System;
using System.Collections.Generic;

namespace Code.Bootstrap.StateMachine
{
    public class GameStateMachine
    {
        private IState _activeState;
        private readonly Dictionary<Type, IState> _states;

        public GameStateMachine(LoadLevelState loadLevelState, GameLoopState gameLoopState)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LoadLevelState)] = loadLevelState,
                [typeof(GameLoopState)] = gameLoopState,
            };
        }
        
        public void Enter<T>() where T : IState
        {
            ChangeCurrentState<T>();
            
            _activeState.Enter();
        }
        
        private void ChangeCurrentState<T>() where T : IState
        {
            if (_activeState is IExitableState exitableState)
                exitableState.Exit();

            if (!_states.ContainsKey(typeof(T)))
                throw new NotImplementedException($"State {typeof(T)} not registered in state machine");

            _activeState = _states[typeof(T)];
        }
    }
}