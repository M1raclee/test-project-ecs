using System;

namespace Code.Services.SceneContent
{
    public interface ISceneContentService : IService
    {
        GameSceneContent GameSceneContent { get; }
        
        void SetupGameSceneContent(GameSceneContent content);
        void CleanUp();
        event Action ContentLoadedEvent;
    }
}