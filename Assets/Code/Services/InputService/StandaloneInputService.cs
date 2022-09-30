using UnityEngine;

namespace Code.Services.InputService
{
    public class StandaloneInputService : IInputService
    {
        public Vector3 Axis =>
            new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}