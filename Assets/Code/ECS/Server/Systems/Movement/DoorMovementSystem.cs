using System.Numerics;
using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems.Movement
{
    public class DoorMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var buttonsFilter = world.Filter<ButtonTag>().Inc<ButtonState>().End();
            var buttonStates = world.GetPool<ButtonState>();

            var doorsFilter = world.Filter<DoorTag>()
                .Inc<MovementInput>().Inc<DoorRestrictions>().Inc<Identifier>().Inc<Location>()
                .End();

            var doorsMovement = world.GetPool<MovementInput>();
            var doorsIdentifiers = world.GetPool<Identifier>();
            var doorRestrictions = world.GetPool<DoorRestrictions>();
            var locations = world.GetPool<Location>();

            foreach (var entity in doorsFilter)
            {
                ref var door = ref doorsMovement.Get(entity);
                door.Axis = Vector3.Zero;
            }

            foreach (var entity in buttonsFilter)
            {
                ref var button = ref buttonStates.Get(entity);
                if (!button.IsPressing)
                    continue;

                foreach (var doorEntity in doorsFilter)
                {
                    ref var movement = ref doorsMovement.Get(doorEntity);
                    ref var identifier = ref doorsIdentifiers.Get(doorEntity);
                    ref var restrictions = ref doorRestrictions.Get(doorEntity);
                    ref var location = ref locations.Get(doorEntity);

                    if (identifier.Guid == button.TargetDoorGuid)
                        if (!IsOpened(location, restrictions))
                            movement.Axis = GetMovementDirection(restrictions);
                }
            }
        }

        private static Vector3 GetMovementDirection(DoorRestrictions restrictions) =>
            restrictions.OpenedPosition - restrictions.ClosedPosition;

        private static bool IsOpened(Location location, DoorRestrictions restrictions) =>
            Vector3.Distance(location.Position, restrictions.OpenedPosition) < 0.1f;
    }
}