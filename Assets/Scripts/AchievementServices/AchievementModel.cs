using AchievementSO;

namespace AchievementServices
{
    public class AchievementModel
    {
        public BulletsFiredAchievementScriptableObject BulletsFiredAchievement { get; private set; }
        public EnemiesKilledAchievementScriptableObject EnemiesKilledAchievement { get; private set; }


        public AchievementModel(AchievementHolder achievements)
        {
            BulletsFiredAchievement = achievements.BulletFiredAchievementSO;
            EnemiesKilledAchievement = achievements.EnemiesKilledAchievementSO;
            
        }
    }
}