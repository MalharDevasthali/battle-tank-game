using Commons;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TankServices;

public class UIService : GenericMonoSingleton<UIService>
{
    public TextMeshProUGUI PopUpText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ScoreText;
    private int currentScore;

    private void Start()
    {
        currentScore = 0;
        ScoreText.text = "Score:" + currentScore.ToString();
    }
    public async void ShowPopUpText(string text, float timeForPopUp)
    {
        PopUpText.enabled = true;
        PopUpText.text = text;
        await new WaitForSeconds(timeForPopUp);
        PopUpText.text = null;
        PopUpText.enabled = false;
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
