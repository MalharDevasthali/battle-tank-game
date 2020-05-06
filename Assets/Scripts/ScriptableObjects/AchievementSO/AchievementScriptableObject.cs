using System;
using UnityEngine;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "AchievementScriptableObject", menuName = "ScriptableObject/Achievement/NewBulletsFiredAchievementSO")]
    public class BulletsFiredAchievementScriptableObject : ScriptableObject
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
            //   public bool isUnlocked;
            public BulletAchievements SelectAchievement;
            public int requirement;
        }
    }
    [CreateAssetMenu(fileName = "AchievementScriptableObject", menuName = "ScriptableObject/Achievement/NewEnemiesKilledAchievementSO")]
    public class EnemiesKilledAchievementScriptableObject : ScriptableObject
    {
        public Tier[] Tiers;

        [Serializable]
        public class Tier
        {
            public enum BulletAchievements
            {
                None,
                Killer,
                SerialKiller,
                Terminator,
                Destroyer
            }
            public BulletAchievements SelectAchievement;
            public int requirement;

        }
    }
    [CreateAssetMenu(fileName = "AchievementScriptableObject", menuName = "ScriptableObject/Achievement/NewAchievementListSO")]
    public class AchievementHolder : ScriptableObject
    {
        public BulletsFiredAchievementScriptableObject BulletFiredAchievementSO;
        public EnemiesKilledAchievementScriptableObject EnemiesKilledAchievementSO;
    }
}