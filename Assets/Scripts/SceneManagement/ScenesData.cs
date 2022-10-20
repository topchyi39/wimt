using UnityEngine;

namespace SceneManagement
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "Scenes/SceneData", order = 0)]
    public class ScenesData : ScriptableObject
    {
        [SerializeField] private string menuSceneName;
        [SerializeField] private string gameSceneName;

        public string MenuSceneName => menuSceneName;
        public string GameSceneName => gameSceneName;
    }
}