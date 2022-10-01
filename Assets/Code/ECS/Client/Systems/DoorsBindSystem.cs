using System.Collections.Generic;
using Code.ECS.Client.Components;
using Code.ECS.Shared.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class DoorsBindSystem : IEcsRunSystem
    {
        private Queue<DoorObject> _doorsObjects;

        public void SetupDoorsObject(DoorObject[] buttons) =>
            _doorsObjects = new Queue<DoorObject>(buttons);
        
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var doorsFilter = world.Filter<DoorTag>().End();
            var doors = world.GetPool<Door>();

            foreach (var entity in doorsFilter)
            {
                if (doors.Has(entity)) 
                    continue;
                
                ref var button = ref doors.Add(entity);

                var objDoor = _doorsObjects.Dequeue();
                button.Target = objDoor;
            }
        }
    }
}