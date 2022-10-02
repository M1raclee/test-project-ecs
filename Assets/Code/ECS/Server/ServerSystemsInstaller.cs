using Code.ECS.Server.Systems.Initialization;
using Code.ECS.Server.Systems.Movement;
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
            Container.Bind<LocationUpdatingSystem>().AsSingle();
        }
    }
}