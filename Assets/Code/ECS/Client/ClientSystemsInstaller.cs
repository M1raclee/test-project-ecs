using Code.ECS.Client.Systems;
using Code.ECS.Client.Systems.Binding;
using Code.ECS.Client.Systems.Movement;
using Zenject;

namespace Code.ECS.Client
{
    public class ClientSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInputSystem>().AsSingle();
            Container.Bind<GameObjectMovementSystem>().AsSingle();
            Container.Bind<CharacterMovementSystem>().AsSingle();
            Container.Bind<PlayerCharacterBindSystem>().AsSingle();
            
            Container.Bind<ButtonsBindSystem>().AsSingle();
            Container.Bind<ButtonsInteractorSystem>().AsSingle();
            Container.Bind<DoorsBindSystem>().AsSingle();
            Container.Bind<LocationUpdatingSystem>().AsSingle();
        }
    }
}