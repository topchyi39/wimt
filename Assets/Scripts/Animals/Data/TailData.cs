using UnityEngine;
using UnityEngine.U2D;

namespace Animals.Data
{
    [CreateAssetMenu(fileName = "TailData", menuName = "Animals/Tails/Data", order = 0)]
    public class TailData : ScriptableObject
    {
        [SerializeField] private SpriteAtlas atlas;
        [SerializeField] private Sprite tailIcon;
        [SerializeField] private Sprite tailSpriteSlot;
        

        public Sprite TailIcon => atlas.GetSprite(tailIcon.name);
        public Sprite TailSpriteSlot => tailSpriteSlot;
    }
}