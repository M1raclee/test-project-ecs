using System.Numerics;
using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems.Movement
{
    public class ButtonsMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var buttonsFilter = world.Filter<ButtonTag>().Inc<ButtonState>().Inc<MovementInput>().Inc<Location>()
                .Inc<PositionRestrictions>().Inc<MovementParams>().End();
            var buttonStates = world.GetPool<ButtonState>();

            var inputs = world.GetPool<MovementInput>();
            var locations = world.GetPool<Location>();
            var posRestrictions = world.GetPool<PositionRestrictions>();
            var movementParams = world.GetPool<MovementParams>();

            foreach (var entity in buttonsFilter)
            {
                ref var input = ref inputs.Get(entity);
                ref var button = ref buttonStates.Get(entity);
                ref var location = ref locations.Get(entity);
                ref var param = ref movementParams.Get(entity);
                ref var restrictions = ref posRestrictions.Get(entity);

                if (button.IsPressing && location.Position.Y > restrictions.MinPosition.Y)
                    input.Axis = new Vector3(0, -param.Speed, 0);
                else if(!button.IsPressing && location.Position.Y < restrictions.MaxPosition.Y) 
                    input.Axis = new Vector3(0, param.Speed, 0);
                else input.Axis = new Vector3(0, 0, 0);
            }
        }
    }
}