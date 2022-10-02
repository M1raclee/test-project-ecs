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
                .Inc<MovementInput>().Inc<PositionRestrictions>().Inc<Identifier>().Inc<Location>()
                .End();

            var doorsMovement = world.GetPool<MovementInput>();
            var doorsIdentifiers = world.GetPool<Identifier>();
            var doorRestrictions = world.GetPool<PositionRestrictions>();
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
                            movement.Axis = GetMovementResult(restrictions);
                }
            }
        }

        private static Vector3 GetMovementResult(PositionRestrictions restrictions) =>
            restrictions.MaxPosition - restrictions.MinPosition;

        private static bool IsOpened(Location location, PositionRestrictions restrictions) =>
            Vector3.Distance(location.Position, restrictions.MaxPosition) < 0.1f;
    }
}