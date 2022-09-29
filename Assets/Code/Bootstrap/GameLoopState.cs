using Code.Bootstrap.StateMachine;
using UnityEngine;

namespace Code.Bootstrap
{
    public class GameLoopState : IEnterableState
    {
        public void Enter() => 
            Debug.Log("Enter game loop state");
    }
}