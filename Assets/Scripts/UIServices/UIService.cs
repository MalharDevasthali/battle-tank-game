using Commons;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIService : GenericMonoSingleton<UIService>
{
    public Image PopUpImage;
    public TextMeshProUGUI PopUpText;
    public TextMeshProUGUI AchievementInfoText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ScoreText;
    public Image PausePanel;
    private int currentScore;

    private void Start()
    {
        currentScore = 0;
        ScoreText.text = "Score:" + currentScore.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.gameObject.SetActive(true);
        }
    }
    public async void ShowPopUpText(string name, string achievementInfo, float timeForPopUp, bool isAchievement = false)
    {
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
            achievementInfo = null;
        PopUpImage.gameObject.SetActive(false);

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
        HealthText.text = "Health: " + currentHealth.ToString();
    }
}
