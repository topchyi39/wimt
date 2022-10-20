using UnityEngine;
using Zenject;

namespace SceneManagement
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>, IInitializable
    {
        [SerializeField] private SceneLoader sceneLoader;
        
        
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle();
        }

        public void Initialize()
        {
            InstallBindings();
        }
    }
}