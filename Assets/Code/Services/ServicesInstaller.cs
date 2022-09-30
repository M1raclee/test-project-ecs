using Code.Services.InputService;
using Code.Services.SceneContent;
using Code.Services.StaticData;
using Zenject;

namespace Code.Services
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneContentService>().To<SceneContentService>().AsSingle();
            Container.Bind(typeof(IInputService), typeof(IInitializable), typeof(ITickable)).To<PointAndClickInputService>().AsSingle();
            Container.Bind(typeof(IStaticData), typeof(IInitializable)).To<StaticDataService>().AsSingle();
        }
    }
}