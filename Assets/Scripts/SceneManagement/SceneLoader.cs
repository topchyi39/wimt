using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UI.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Fader fader;
        [SerializeField] private ScenesData scenesData;

        [ContextMenu("Load Game")]
        public async Task LoadGameScene()
        {
            await LoadSceneAsync(scenesData.GameSceneName);
        }
        
        [ContextMenu("Load Menu")]
        public async Task LoadMenuScene()
        {
            await LoadSceneAsync(scenesData.MenuSceneName);
        }

        private async Task LoadSceneAsync(string sceneName)
        {
            await fader.FadeIn();
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            await asyncOperation;
            await fader.FadeOut();
        }
    }
}