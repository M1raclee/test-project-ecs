using Code.Services.SceneContent;
using Zenject;

namespace Code.Services
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<ISceneContentService>().To<SceneContentService>().AsSingle();
    }
}