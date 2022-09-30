using UnityEngine;

namespace Code.Data
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Static Data/Player Data")]
    public class PlayerData : ScriptableObject
    {
        public float MovementSpeed;
        public float Gravity;
    }
}