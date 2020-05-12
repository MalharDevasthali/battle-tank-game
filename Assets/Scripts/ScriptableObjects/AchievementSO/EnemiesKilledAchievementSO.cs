using System;
using UnityEngine;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "EnemiesKilledAchievementSO", menuName = "ScriptableObject/Achievement/NewEnemiesKilledAchievementSO")]
    public class EnemiesKilledAchievementSO : ScriptableObject
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
}