using Code.ECS.Client.Systems;
using Code.Services.SceneContent;
using UnityEngine;
using Zenject;

namespace Code.Bootstrap.Scene
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameSceneContent _sceneContent;
        
        public override void InstallBindings() => 
            Container.BindInterfacesAndSelfTo<SceneInitializer>().AsSingle().WithArguments(_sceneContent).NonLazy();
    }
}