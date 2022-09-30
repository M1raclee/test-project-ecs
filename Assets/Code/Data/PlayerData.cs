using UnityEngine;

namespace Code.Data
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Static Data/Player Data")]
    public class PlayerData : ScriptableObject
    {
        public float MovementSpeed = 8f;
        public float Gravity = -20f;
        public float MovementThreshold = 0.5f;
    }
}