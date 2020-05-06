
using UnityEngine;
using TankServices;

namespace AchievementServices
{
    public class AchievementController
    {
        public AchievementModel model { get; private set; }
        public TankModel tankModel { get; private set; }
        private int currentBulletFiredAchievementTier;
        private int currentEnemiesKilledtAchievementTier;


        public AchievementController(AchievementModel _model)
        {
            currentBulletFiredAchievementTier = 0;
            currentEnemiesKilledtAchievementTier = 0;
            model = _model;
            SetTankModel();
        }
        public void CheckForBulletFiredAchievement()
        {
            for (int i = 0; i < model.BulletsFiredAchievement.Tiers.Length; i++)
            {
                if (i > currentBulletFiredAchievementTier) continue;
                if (tankModel.BulletsFired == model.BulletsFiredAchievement.Tiers[i].requirement)
                {
                    UnlockAchievement(model.BulletsFiredAchievement.Tiers[i].SelectAchievement.ToString());
                    currentBulletFiredAchievementTier = i;
                }
            }
        }

        public void CheckForEnemiesKilledAchievement()
        {
            for (int i = 0; i < model.EnemiesKilledAchievement.Tiers.Length; i++)
            {
                if (i > currentEnemiesKilledtAchievementTier) continue;
                if (tankModel.EnemiesKilled == model.EnemiesKilledAchievement.Tiers[i].requirement)
                {
                    UnlockAchievement(model.EnemiesKilledAchievement.Tiers[i].SelectAchievement.ToString());
                }
                currentEnemiesKilledtAchievementTier = i;
            }
        }

        //Tried hard for generic achievement check but failed...
        // public void CheckForAchievementComplete( int done, int requirement, int tierLength, string achievementName)
        // {
        //     //for (int i = 0; i < tierLength; i++)
        //     //{
        //     //    if (i < currentTier) continue;
        //     if (done == requirement)
        //     {
        //         UnlockAchievement(achievementName);

        //     }
        //     //  }
        // }
        private void UnlockAchievement(string achievementName)
        {
            Debug.Log(achievementName + "Unlocked");
            UIService.instance.ShowPopUpText(achievementName, 2f);
        }
        async private void SetTankModel()
        {
            await new WaitForEndOfFrame();
            tankModel = TankService.instance.GetCurrentTankModel();
        }
        public void ResetAchievements()
        {
            currentBulletFiredAchievementTier = 0;
            currentEnemiesKilledtAchievementTier = 0;
            // if (tankModel != null)
            // {
            //     tankModel.BulletsFired = 0;
            //     tankModel.EnemiesKilled = 0;
            // }
        }
    }
}