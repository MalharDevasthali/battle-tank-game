using UnityEngine;
using Commons;
using EnemyServices;
using SFXServices;
using UIServices;
using TankServices;
namespace GameServices
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public bool gamePaused = false;
        public bool gameOver = false;
        private string currentPlayerName;
        private int highScore;
        private string recordHolderName;

        private void Start()
        {

            //  PlayerPrefs.SetInt("highScore", 0);
            highScore = PlayerPrefs.GetInt("highScore", 0);
            currentPlayerName = PlayerPrefs.GetString("currentPlayerName", "");
            //  PlayerPrefs.SetString("recordHolderName", "Malhar Devasthali");
            recordHolderName = PlayerPrefs.GetString("recordHolderName", "-");
        }

        public void GamePaused()
        {

            SFXService.instance.TurnOffSoundsExceptUI();
            EnemyService.instance.TurnOFFEnemies();
            TankService.instance.TurnOFFTanks();

            gamePaused = true;
        }
        public void SetCurrentPlayerName(string name)
        {
            currentPlayerName = name;
            PlayerPrefs.SetString("currentPlayerName", currentPlayerName);
            Debug.Log(PlayerPrefs.GetString("currentPlayerName"));
        }
        private string GetCurrentPlayerName()
        {
            return currentPlayerName;
        }
        public void CheckForHighScore()
        {
            if (UIService.instance.GetCurrentScore() > highScore)
            {
                PlayerPrefs.SetInt("highScore", UIService.instance.GetCurrentScore());
                highScore = UIService.instance.GetCurrentScore();
                PlayerPrefs.SetString("recordHolderName", PlayerPrefs.GetString("currentPlayerName"));
                recordHolderName = GetCurrentPlayerName();
            }
        }
        public void GameResumed()
        {
            SFXService.instance.ResetSounds();
            EnemyService.instance.TurnONEnmeis();
            TankService.instance.TurnONTanks();

            gamePaused = false;
        }
        public void SetHighScore(int _highScore)
        {
            highScore = _highScore;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        public void SetRecordHolder(string name)
        {
            recordHolderName = name;
            PlayerPrefs.SetString("recordHolderName", recordHolderName);
        }
        public string GetHighScore()
        {
            return highScore.ToString();
        }
        public string GetRecordHolder()
        {
            return recordHolderName;
        }

    }
}
