using System.Collections.Generic;
using UnityEngine;

namespace Code.Markers
{
    [RequireComponent(typeof(Rigidbody))]
    public class CollisionDetector : MonoBehaviour
    {
        public HashSet<Collision> StayedCollisions = new();

        private void OnCollisionEnter(Collision other) =>
            StayedCollisions.Add(other);

        private void OnCollisionExit(Collision other) =>
            StayedCollisions.Remove(other);

        private void Update()
        {
            Debug.Log($"Stayed collisions {StayedCollisions.Count}");
        }
    }
}