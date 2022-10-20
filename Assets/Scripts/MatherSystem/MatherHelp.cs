using System.Collections;
using Animals.Tails;
using UI.Tools;
using UnityEngine;

namespace MatherSystem
{
    public class MatherHelp : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Transform pointer;
        [SerializeField] private float duration;

        private bool _isShowing;
        
        public void ShowPointer(Tail tail)
        {
            StartCoroutine(PointerRoutine(tail));
        }

        private IEnumerator PointerRoutine(Tail tail)
        {
            _isShowing = true;
            var tailTransform = tail.transform;
            canvasGroup.SetVisible(true);
            while (_isShowing)
            {
                var time = 0f;
                tail.Pulse();
                canvasGroup.SetVisible(true);
                while (time < duration)
                {
                    pointer.position = Vector3.Lerp(tailTransform.position, Vector3.zero, time / duration);
                    time += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }

                canvasGroup.SetVisible(false);
                yield return new WaitForSeconds(1f);
            }

            canvasGroup.SetVisible(false);
        }

        public void Hide()
        {
            _isShowing = false;
            canvasGroup.SetVisible(false);
        }
    }
}