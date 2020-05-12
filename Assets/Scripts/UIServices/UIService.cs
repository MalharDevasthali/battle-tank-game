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


    public async void ShowPopUpText(string text, float timeForPopUp)
    {
        PopUpText.enabled = true;
        PopUpText.text = text;
        await new WaitForSeconds(timeForPopUp);
        PopUpText.text = null;
        PopUpText.enabled = false;
    }

    public void UpdateScoreText(int currentScore, int scoreMultiplier = 1)
    {
        int finalScore = (currentScore * 10) * scoreMultiplier;
        ScoreText.text = "Score: " + finalScore.ToString();

    }

    public void UpdateHealthText(float currentHealth)
    {
        HealthText.text = "Health: " + currentHealth.ToString();
    }
}
