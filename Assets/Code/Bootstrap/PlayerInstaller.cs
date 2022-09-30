using UnityEngine;
using Zenject;

namespace Code.Bootstrap
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerObject _player;

        public override void InstallBindings() => 
            Container.BindInterfacesAndSelfTo<PlayerObject>().FromInstance(_player);
    }
}