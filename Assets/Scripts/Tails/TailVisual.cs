using Cysharp.Threading.Tasks;
using Visual;
using UnityEngine;
using UnityEngine.UI;

namespace Tails
{
    public class TailVisual : Object2DVisual
    {
        [SerializeField] private Image tailImage;
        [SerializeField] private Outline outline;
        
        
        
        [Header("PulseSettings")] 
        [SerializeField] private AnimationCurve pulseCurve;

        private void Start()
        {
            outline.enabled = false;
        }

        public void SetImage(Sprite sprite)
        {
            tailImage.sprite = sprite;
            tailImage.SetNativeSize();
        }

        public async void Pulse(Color outlineColor)
        {
            outline.effectColor = outlineColor;
            outline.enabled = true;
            var time = 0f;
            var vectorSize = Vector3.one;
            while (time <= 1f)
            {
                rootTransform.localScale = vectorSize * pulseCurve.Evaluate(time);
                time += Time.deltaTime;
                await UniTask.WaitForEndOfFrame(this);
            }
            outline.enabled = false;
        }
    }
}