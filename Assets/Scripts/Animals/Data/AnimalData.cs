using Spine;
using Spine.Unity;
using UnityEngine;

namespace Animals.Data
{
    [CreateAssetMenu(fileName = "AnimalData", menuName = "Animals/Data", order = 0)]
    public class AnimalData : ScriptableObject
    {
        [SerializeField] private SkeletonDataAsset skeletonDataAsset;
        [SerializeField] private string skin = "default";
        
        
        [Space]
        [SerializeField] private Sprite animalIcon;
        [SerializeField] private AnimalSoundsData sounds;
        [SerializeField] private AnimalAnimationData animations;
        

        [Header("Tail")]
        [SerializeField] private TailData tailData;
        [SerializeField] private string tailName;
        [SerializeField] private string tailBone;

        

        public SkeletonDataAsset SkeletonDataAsset => skeletonDataAsset;
        public string SkinName => skin;
        public AnimalSoundsData Sounds => sounds;
        public AnimalAnimationData Animations => animations;
        
        public Sprite Icon => animalIcon;
        public TailData TailData => tailData;
        public string TailName => tailName;
        public string TailBone => tailBone;

        public Slot SetDataAndGetTail(SkeletonAnimation skeleton)
        {
            skeleton.skeletonDataAsset = skeletonDataAsset;
            skeleton.Initialize(true);
            skeleton.skeleton.SetSkin(skin);
            skeleton.Skeleton.SetSlotsToSetupPose();
            return skeleton.Skeleton.FindSlot(tailName);
        }

        public bool CompareTails(TailData data)
        {
            return tailData == data;
        }
    }
}