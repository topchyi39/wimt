using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Extensions;
using UnityEngine;

namespace UI.Tools
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Fader : MonoBehaviour
    {
        [SerializeField] private AnimationCurve curveIn;
        [SerializeField] private AnimationCurve curveOut;
        
        [SerializeField] private float timeToFadeIn;
        [SerializeField] private float timeToFadeOut;
        
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public async Task FadeIn()
        {
            await FadeRoutine(true);
        }

        public async Task FadeOut()
        {
            await FadeRoutine(false);
        }

        private async Task FadeRoutine(bool visible)
        {
            var endValue = visible ? 1 : 0;
            var startValue = Mathf.Abs(endValue - 1);

            var curve = visible ? curveIn : curveOut;
            var targetTime = visible ? timeToFadeIn : timeToFadeOut;

            var time = 0f;

            _canvasGroup.SetVisible(!visible);
            
            while (time <= targetTime)
            {
                var value = curve.Evaluate(time / targetTime);
                value = value.Remap(0f, 1f, startValue, endValue);
                _canvasGroup.alpha = value;
                time += Time.deltaTime;
                await UniTask.WaitForEndOfFrame(this);
            }

            _canvasGroup.SetVisible(visible);
        }
    }
}