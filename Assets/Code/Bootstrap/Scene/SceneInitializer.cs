using Code.Services.SceneContent;
using Zenject;

namespace Code.Bootstrap.Scene
{
    public class SceneInitializer : IInitializable
    {
        private readonly ISceneContentService _sceneContentService;
        private readonly GameSceneContent _sceneContent;

        public SceneInitializer(ISceneContentService sceneContentService, GameSceneContent sceneContent)
        {
            _sceneContentService = sceneContentService;
            _sceneContent = sceneContent;
        }
        
        public void Initialize() => 
            _sceneContentService.SetupGameSceneContent(_sceneContent);
    }
}