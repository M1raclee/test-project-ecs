using Code.ECS.Server.Systems;
using Zenject;

namespace Code.ECS.Server
{
    public class ServerSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInitializeSystem>().AsSingle();
            Container.Bind<VelocityMovementSystem>().AsSingle();
        }
    }
}