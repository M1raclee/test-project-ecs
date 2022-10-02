using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Code.Services.StaticData;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems.Initialization
{
    public class ButtonInitializeSystem : IEcsInitSystem
    {
        private readonly IStaticData _staticData;

        public ButtonInitializeSystem(IStaticData staticData) =>
            _staticData = staticData;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var buttonsData = _staticData.ForButtons();
            
            for (var i = 0; i < buttonsData.TotalCount; i++)
            {
                var button = world.NewEntity();
                
                world.GetPool<ButtonTag>().Add(button);
                world.GetPool<ButtonState>().Add(button);
                world.GetPool<Location>().Add(button);
                world.GetPool<MovementInput>().Add(button);
                world.GetPool<MovementResult>().Add(button);
                world.GetPool<PositionRestrictions>().Add(button);
                ref var param = ref world.GetPool<MovementParams>().Add(button);
                
                param.Speed = buttonsData.MovingSpeed;
                param.Equalizer = 0.001f;
            }
        }
    }
}