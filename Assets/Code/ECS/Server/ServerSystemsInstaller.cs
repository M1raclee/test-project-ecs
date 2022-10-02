using Code.ECS.Server.Systems;
using Zenject;

namespace Code.ECS.Server
{
    public class ServerSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInitializeSystem>().AsSingle();
            Container.Bind<MovementSystem>().AsSingle();
            
            Container.Bind<ButtonInitializeSystem>().AsSingle();
            Container.Bind<DoorsInitializeSystem>().AsSingle();
            Container.Bind<DoorMovementSystem>().AsSingle();
        }
    }
}