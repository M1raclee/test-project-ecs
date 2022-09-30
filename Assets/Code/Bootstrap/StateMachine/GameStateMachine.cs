using System;
using System.Collections.Generic;
using Zenject;

namespace Code.Bootstrap.StateMachine
{
    public class GameStateMachine : ITickable
    {
        private IState _activeState;
        private readonly Dictionary<Type, IState> _states;

        public GameStateMachine(LoadLevelState loadLevelState, GameLoopState gameLoopState,
            SystemsRegistrationState systemsRegistrationState)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LoadLevelState)] = loadLevelState,
                [typeof(SystemsRegistrationState)] = systemsRegistrationState,
                [typeof(GameLoopState)] = gameLoopState,
            };
        }

        public void Enter<T>() where T : IState
        {
            ChangeCurrentState<T>();

            if (_activeState is IEnterableState enterableState)
                enterableState.Enter();
        }

        public void Enter<T, TPayload>(TPayload payload) where T : IState
        {
            ChangeCurrentState<T>();

            if (_activeState is IPayloadState<TPayload> payloadState)
                payloadState.Enter(payload);
        }

        public void Tick()
        {
            if(_activeState is IUpdatableState updatableState)
                updatableState.Update();
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