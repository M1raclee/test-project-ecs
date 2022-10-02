using System;
using Code.Services.SceneContent;
using Code.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Services.InputService
{
    public class PointAndClickInputService : IInputService, IInitializable, ITickable, IDisposable
    {
        public Vector3 Axis => CalculateDirection();

        private readonly IStaticData _staticData;
        private readonly ISceneContentService _sceneContentService;

        private Transform _target;
        private Camera _camera;
        private Vector3 _destination;
        private LayerMask _groundLayer;
        private bool _isDestinationSet;

        public PointAndClickInputService(IStaticData staticData, ISceneContentService sceneContentService)
        {
            _staticData = staticData;
            _sceneContentService = sceneContentService;
        }

        public void Initialize()
        {
            _groundLayer = 1 << LayerMask.NameToLayer("Ground");
            _sceneContentService.ContentLoadedEvent += SceneContentLoadedHandler;
        }

        private void SceneContentLoadedHandler()
        {
            _target = _sceneContentService.GameSceneContent.Player.transform;
            _camera = _sceneContentService.GameSceneContent.Camera;
        }

        public void Tick() =>
            TrackMouseClick();

        public void Dispose() =>
            _sceneContentService.ContentLoadedEvent -= SceneContentLoadedHandler;

        private void TrackMouseClick()
        {
            if (Input.GetMouseButtonDown(0))
                _isDestinationSet = TryToGetMouseClickWorldPosition(out _destination);
        }

        private bool TryToGetMouseClickWorldPosition(out Vector3 worldPosition)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitData, 1000, _groundLayer))
            {
                worldPosition = hitData.point;
                return true;
            }

            worldPosition = default;
            return false;
        }

        private Vector3 CalculateDirection()
        {
            if (!_isDestinationSet)
                return Vector3.zero;

            var distance = Distance(_destination, _target.position);

            if (distance < _staticData.ForPlayer().MovementThreshold)
                return Vector3.zero;

            var direction = (_destination - _target.position).normalized;

            return direction;
        }

        private float Distance(Vector3 destination, Vector3 current)
        {
            var num1 = destination.x - current.x;
            var num2 = destination.z - current.z;
            return (float) Math.Sqrt(num1 * num1 + num2 * num2);
        }
    }
}