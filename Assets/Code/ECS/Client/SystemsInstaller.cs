using Code.ECS.Client.Systems;
using Zenject;

namespace Code.ECS.Client
{
    public class SystemsInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<PlayerInitializeSystem>().AsSingle();
    }
}