using Code.Services.SceneContent;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Bootstrap.StateMachine
{
    public class GameLoopState : IEnterableState, IUpdatableState, IExitableState
    {
        private readonly EcsSystems _systems;
        private readonly ISceneContentService _sceneContentService;

        public GameLoopState(EcsSystems systems, ISceneContentService sceneContentService)
        {
            _systems = systems;
            _sceneContentService = sceneContentService;
        }

        public void Enter() => 
            Debug.Log("Enter game loop state");

        public void Update() => 
            _systems.Run();

        public void Exit() => 
            _sceneContentService.CleanUp();
    }
}