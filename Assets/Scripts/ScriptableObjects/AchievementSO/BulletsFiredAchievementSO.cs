using System;
using UnityEngine;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "BulletsFiredAchievementSO", menuName = "ScriptableObject/Achievement/NewBulletsFiredAchievementSO")]
    public class BulletsFiredAchievementSO : ScriptableObject
    {
        public Tier[] Tiers;

        [Serializable]
        public class Tier
        {
            public enum BulletAchievements
            {
                None,
                BulletsLover_I,
                BulletsLover_II,
                BulletsLover_III,
                BulletsLover_IV,
            }
            public BulletAchievements SelectAchievement;
            public int requirement;
        }
    }
}