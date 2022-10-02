using System.Collections.Generic;
using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems.Binding
{
    public class DoorsBindSystem : IEcsRunSystem
    {
        private Queue<DoorObject> _doorsObjects;

        public void SetupDoorsObject(DoorObject[] buttons) =>
            _doorsObjects = new Queue<DoorObject>(buttons);

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var doorsFilter = world.Filter<DoorTag>().Inc<Identifier>().End();
            var gameObjects = world.GetPool<GameObject>();
            var doorIdentifiers = world.GetPool<Identifier>();

            foreach (var entity in doorsFilter)
            {
                if (gameObjects.Has(entity))
                    continue;
                
                ref var door = ref gameObjects.Add(entity);
                ref var identifier = ref doorIdentifiers.Get(entity);

                var objDoor = _doorsObjects.Dequeue();
                door.Transform = objDoor.transform;
                identifier.Guid = objDoor.Guid;
            }
        }
    }
}