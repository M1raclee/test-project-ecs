using Code.ECS.Shared.Data;
using UnityEngine;

namespace Code.Data
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Static Data/Player Data")]
    public class PlayerData : ScriptableObject, IPlayerData
    {
        [field: SerializeField] public float MovementSpeed { get; private set; } = 8f;
        [field: SerializeField] public float Gravity { get; private set; } = -20f;
        [field: SerializeField] public float MovementThreshold { get; private set; } = 0.5f;
    }
}