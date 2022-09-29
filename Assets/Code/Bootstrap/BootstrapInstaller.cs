using Code.Bootstrap.StateMachine;
using Zenject;

namespace Code.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrapper>().AsSingle().NonLazy();
            
            BindGameStateMachineStates();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }

        private void BindGameStateMachineStates()
        {
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
        }
    }
}