using Commons;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameServices;

namespace UIServices
{

    public class UIService : GenericMonoSingleton<UIService>
    {
        public Image PopUpImage;
        public TextMeshProUGUI PopUpText;
        public TextMeshProUGUI AchivementNameText;
        public TextMeshProUGUI AchievementInfoText;
        public Image AchievementImage;
        public TextMeshProUGUI HealthText;
        public TextMeshProUGUI ScoreText;
        public GameObject PausePanel;
        public GameObject GameOverPanel;
        private int currentScore;

        private void Start()
        {
            currentScore = 0;
            ScoreText.text = "Score:" + currentScore.ToString();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !GameService.instance.gamePaused)
            {

                GameService.instance.GamePaused();
                PausePanel.SetActive(true);
            }
            else if (GameService.instance.gamePaused && Input.GetKeyDown(KeyCode.Escape))
            {
                GameService.instance.GameResumed();
                PausePanel.SetActive(false);
            }
        }
        public async void ShowPopUpText(string name, float timeForPopUp, string achievementInfo = null, bool isAchievement = false)
        {
            GameService.instance.GamePaused();
            if (isAchievement)
            {
                PopUpText.text = "Achievement Unlocked!\n";
                AchievementInfoText.text = achievementInfo;
            }
            PopUpImage.gameObject.SetActive(true);
            PopUpText.text = PopUpText.text + name;
            await new WaitForSeconds(timeForPopUp);
            PopUpText.text = null;
            if (isAchievement)
                AchievementInfoText.text = null;
            PopUpImage.gameObject.SetActive(false);
            GameService.instance.GameResumed();

        }
        public async void ShowAchievementUnlocked(string name, string achievementInfo, float timeForPopUp)
        {
            GameService.instance.GamePaused();
            AchivementNameText.text = "Achievement Unlocked!\n";
            AchievementInfoText.text = achievementInfo;
            AchievementImage.gameObject.SetActive(true);
            AchivementNameText.text = AchivementNameText.text + name;
            await new WaitForSeconds(timeForPopUp);
            AchivementNameText.text = null;
            AchievementImage.gameObject.SetActive(false);
            GameService.instance.GameResumed();
        }
        public void ShowGameOverUI()
        {
            GameService.instance.GamePaused();
            GameOverPanel.SetActive(true);
        }
        public int GetCurrentScore()
        {
            return currentScore;
        }

        public void UpdateScoreText(int scoreMultiplier = 1)
        {
            int finalScore = (currentScore + 10) * scoreMultiplier;
            currentScore = finalScore;
            ScoreText.text = "Score: " + finalScore.ToString();

        }
        public void ResetScore()
        {
            currentScore = 0;
            ScoreText.text = "Score: " + currentScore.ToString();
        }

        public void UpdateHealthText(float currentHealth)
        {
            if (currentHealth < 0) currentHealth = 0;
            HealthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
