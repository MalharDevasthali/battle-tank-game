using UnityEngine;
using Commons;
using EnemyServices;
using SFXServices;
using UIServices;
using TankServices;
using UnityEngine.SceneManagement;
namespace GameServices
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public bool gamePaused = false;
        public bool gameOver = false;
        static private string currentPlayerName;
        private int highScore;
        private string recordHolderName;
        private float currentWave;


        private void Start()
        {
            currentWave = 0;
            highScore = PlayerPrefs.GetInt("highScore", PlayerPrefs.GetInt("highScore"));
            recordHolderName = PlayerPrefs.GetString("recordHolderName", PlayerPrefs.GetString("recordHolderName"));
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GamePaused()
        {
            gamePaused = true;
            SFXService.instance.TurnOffSoundsExceptUI();
            EnemyService.instance.TurnOFFEnemies();
            TankService.instance.TurnOFFTanks();
        }
        public void SetCurrentPlayerName(string name)
        {
            currentPlayerName = name;
            Debug.Log("GameService, SetCurrentPlayerName() ->" + currentPlayerName);
            // PlayerPrefs.SetString("currentPlayerName", currentPlayerName);
        }
        public void CheckForHighScore()
        {

            if (UIService.instance.GetCurrentScore() > highScore)
            {

                Debug.Log("GameService,CheckForHighScore : CurrentPlayer->" + currentPlayerName);
                PlayerPrefs.SetInt("highScore", UIService.instance.GetCurrentScore());
                PlayerPrefs.SetString("recordHolderName", currentPlayerName);
                recordHolderName = PlayerPrefs.GetString("recordHolderName");
                highScore = UIService.instance.GetCurrentScore();
            }
        }
        public void GameResumed()
        {
            gamePaused = false;
            SFXService.instance.ResetSounds();
            EnemyService.instance.TurnONEnmeis();
            TankService.instance.TurnONTanks();
        }
        public string GetHighScore()
        {

            return PlayerPrefs.GetInt("highScore").ToString();
        }
        public string GetRecordHolder()
        {
            return PlayerPrefs.GetString("recordHolderName");
        }
    }
}
