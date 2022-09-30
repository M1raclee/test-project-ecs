using Code.Bootstrap.StateMachine;
using Leopotam.EcsLite;
using Zenject;

namespace Code.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrapper>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EcsWorld>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EcsSystems>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

            BindGameStateMachineStates();
        }

        private void BindGameStateMachineStates()
        {
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemsRegistrationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
        }
    }
}