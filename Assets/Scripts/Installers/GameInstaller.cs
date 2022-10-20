using Animals;
using Animals.Tails;
using Tails;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private TailSpawner tailSpawner;
        [SerializeField] private AnimalSpawner animalSpawner;

        public override void InstallBindings()
        {
            Container.Bind<TailSpawner>().FromInstance(tailSpawner).AsSingle();
            Container.Bind<AnimalSpawner>().FromInstance(animalSpawner).AsSingle();
        }
    }
}