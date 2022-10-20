using UnityEngine;
using Zenject;

namespace Animals
{
    public class AnimalInstaller : MonoInstaller<AnimalInstaller>, IInitializable
    {
        [SerializeField] private AnimalHolder holder;

        public override void InstallBindings()
        {
            Container.Bind<AnimalHolder>().FromInstance(holder).AsSingle();
        }

        public void Initialize()
        {
            InstallBindings();
        }
    }
}