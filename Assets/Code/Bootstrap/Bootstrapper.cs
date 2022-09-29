using Code.Bootstrap.StateMachine;
using Zenject;

namespace Code.Bootstrap
{
    public class Bootstrapper : IInitializable
    {
        private const string GameScene = "Game";
        private readonly GameStateMachine _gameStateMachine;

        public Bootstrapper(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Initialize() => 
            _gameStateMachine.Enter<LoadLevelState, string>(GameScene);
    }
}
