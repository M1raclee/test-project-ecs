using Code.Data;
using Code.ECS.Shared.Data;
using Code.Services.SceneContent;
using UnityEngine;
using Zenject;

namespace Code.Services.StaticData
{
    public class StaticDataService : IStaticData, IInitializable
    {
        private readonly ISceneContentService _sceneContentService;
        private const string DataPlayerDataPath = "Data/Player Data";

        private PlayerData _playerData;

        public StaticDataService(ISceneContentService sceneContentService) =>
            _sceneContentService = sceneContentService;

        public void Initialize() =>
            LoadData();

        private void LoadData() =>
            // TODO: add asset service
            _playerData = Resources.Load<PlayerData>(DataPlayerDataPath);

        public IPlayerData ForPlayer() =>
            _playerData;

        // we need gotta server know how many buttons on scene (and, probably, its config)
        // for simplify this process without server-side architecture
        // just pass it from scene content
        public IButtonsData ForButtons() => 
            new ButtonsData {TotalCount = _sceneContentService.GameSceneContent.Buttons.Length};

        // also for doors
        public IDoorsData ForDoors() =>
            new DoorsData {TotalCount = _sceneContentService.GameSceneContent.Doors.Length};
    }
}