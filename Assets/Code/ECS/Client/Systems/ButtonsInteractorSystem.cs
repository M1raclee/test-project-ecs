using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class ButtonsInteractorSystem : IEcsRunSystem
    {
        private const string ButtonTag = "Button";

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var detectorsFilter = world.Filter<CollisionDetector>().Inc<ButtonsInteractor>().End();
            var buttonsFilter = world.Filter<ButtonState>().End();
            var detectors = world.GetPool<CollisionDetector>();
            var buttonStates = world.GetPool<ButtonState>();

            foreach (var entity in buttonsFilter)
            {
                ref var button = ref buttonStates.Get(entity);
                button.IsPressing = false;
            }

            foreach (var entity in detectorsFilter)
            {
                ref var detector = ref detectors.Get(entity);
                foreach(var col in detector.Detector.StayedCollisions)
                    if (col.collider.CompareTag(ButtonTag))
                    {
                        var btnObject = col.collider.GetComponent<ButtonObject>();
                        ref var button = ref buttonStates.Get(btnObject.Entity);

                        button.IsPressing = true;
                    }
            }
        }
    }
}