using System;

namespace Code.Services.SceneContent
{
    public interface ISceneContentService : IService
    {
        event Action ContentLoadedEvent;
        
        GameSceneContent GameSceneContent { get; }

        void SetupGameSceneContent(GameSceneContent content);
        void CleanUp();
    }
}