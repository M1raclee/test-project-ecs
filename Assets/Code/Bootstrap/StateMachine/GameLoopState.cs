using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Bootstrap.StateMachine
{
    public class GameLoopState : IEnterableState, IUpdatableState
    {
        private readonly EcsSystems _systems;

        public GameLoopState(EcsSystems systems) => 
            _systems = systems;

        public void Enter() => 
            Debug.Log("Enter game loop state");

        public void Update() => 
            _systems.Run();
    }
}