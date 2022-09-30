using System;

namespace Code.Services.SceneContent
{
    public class SceneContentService : ISceneContentService
    {
        public event Action ContentLoadedEvent;
        
        public GameSceneContent GameSceneContent { get; private set; }

        public void SetupGameSceneContent(GameSceneContent content)
        {
            GameSceneContent = content;
            ContentLoadedEvent?.Invoke();
        }

        public void CleanUp() => 
            GameSceneContent = null;
    }
}