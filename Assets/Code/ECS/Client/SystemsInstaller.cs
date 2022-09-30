using Code.ECS.Client.Systems;
using Code.ECS.Server.Systems;
using Zenject;

namespace Code.ECS.Client
{
    public class SystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInitializeSystem>().AsSingle();
            Container.Bind<PlayerMovementSystem>().AsSingle();
            Container.Bind<GameObjectMovementSystem>().AsSingle();
            Container.Bind<MovementSystem>().AsSingle();
        }
    }
}