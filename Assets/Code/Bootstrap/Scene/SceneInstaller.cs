using Code.ECS.Client.Systems;
using Zenject;

namespace Code.Bootstrap.Scene
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneSystemsInitializer>().AsSingle().NonLazy();
            RegisterSceneContextSystems();
        }

        private void RegisterSceneContextSystems() =>
            Container.Bind<PlayerInitializeSystem>().AsSingle();
    }
}