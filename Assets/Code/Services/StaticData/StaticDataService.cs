using Code.Data;
using UnityEngine;
using Zenject;

namespace Code.Services.StaticData
{
    public class StaticDataService : IStaticData, IInitializable
    {
        private const string DataPlayerDataPath = "Data/Player Data";

        private PlayerData _playerData;

        public void Initialize() =>
            LoadData();

        private void LoadData() =>
            // TODO: add asset service
            _playerData = Resources.Load<PlayerData>(DataPlayerDataPath);

        public PlayerData ForPlayer() =>
            _playerData;
    }
}