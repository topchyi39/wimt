using SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Buttons
{
    public class ToMenuButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            button.onClick.AddListener(ToMenu);
        }

        private void ToMenu()
        {
            _sceneLoader.LoadMenuScene();
        }
    }
}