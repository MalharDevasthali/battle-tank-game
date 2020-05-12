
using UnityEngine;
using TankServices;

namespace AchievementServices
{
    public class AchievementController
    {
        public AchievementModel model { get; private set; }
        private int currentBulletFiredAchievementTier;
        private int currentEnemiesKilledtAchievementTier;


        public AchievementController(AchievementModel _model)
        {
            currentBulletFiredAchievementTier = PlayerPrefs.GetInt("currentBulletFiredAchievementTier", 0);
            currentEnemiesKilledtAchievementTier = PlayerPrefs.GetInt("currentEnemiesKilledtAchievementTier", 0);
            model = _model;
        }
        public void CheckForBulletFiredAchievement()
        {
            for (int i = 0; i < model.BulletsFiredAchievement.Tiers.Length; i++)
            {
                if (i != currentBulletFiredAchievementTier) continue;
                if (TankService.instance.GetCurrentTankModel().BulletsFired == model.BulletsFiredAchievement.Tiers[i].requirement)
                {
                    UnlockAchievement(model.BulletsFiredAchievement.Tiers[i].SelectAchievement.ToString());
                    currentBulletFiredAchievementTier = i + 1;
                    PlayerPrefs.SetInt("currentBulletFiredAchievementTier", currentBulletFiredAchievementTier);
                }
                break;
            }
        }

        public void CheckForEnemiesKilledAchievement()
        {
            for (int i = 0; i < model.EnemiesKilledAchievement.Tiers.Length; i++)
            {
                if (i != currentEnemiesKilledtAchievementTier) continue;
                if (TankService.instance.GetCurrentTankModel().EnemiesKilled == model.EnemiesKilledAchievement.Tiers[i].requirement)
                {
                    UnlockAchievement(model.EnemiesKilledAchievement.Tiers[i].SelectAchievement.ToString());
                    currentEnemiesKilledtAchievementTier = i + 1;
                    PlayerPrefs.SetInt("currentEnemiesKilledtAchievementTier", currentEnemiesKilledtAchievementTier);
                }
                break;
            }
        }

        private void UnlockAchievement(string achievementName)
        {
            Debug.Log(achievementName + "Unlocked");
            UIService.instance.ShowPopUpText(achievementName, 2f);
        }
    }
}