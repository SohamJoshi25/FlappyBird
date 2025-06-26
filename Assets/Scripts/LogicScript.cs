using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;
    public GameObject Pausebutton;
    public GameObject pauseOverScreen;
  [SerializeField] private AudioClip mainBGMclip;
[SerializeField] private AudioClip deathSFXclip;
[SerializeField] private AudioClip pointSFXclip;

private AudioSource mainBGMSound;
private AudioSource deathSFX;
private AudioSource pointSFX;

public bool isGameOver = false;

    public void Awake()
    {
        float volume = PlayerPrefs.GetFloat("volume", 0.5f);

        mainBGMSound = gameObject.AddComponent<AudioSource>();
        mainBGMSound.clip = mainBGMclip;
        mainBGMSound.volume = volume*0.5f;
        mainBGMSound.loop = true;
        mainBGMSound.playOnAwake = true;
        mainBGMSound.Play();

        deathSFX = gameObject.AddComponent<AudioSource>();
        deathSFX.clip = deathSFXclip;
        deathSFX.volume = volume;
        deathSFX.playOnAwake = false;

        pointSFX = gameObject.AddComponent<AudioSource>();
        pointSFX.clip = pointSFXclip;
        pointSFX.volume = volume;
        pointSFX.playOnAwake = false;
    }


    public void Start()
    {
        isGameOver = false;
        highScore = PlayerPrefs.GetInt("highscore", highScore);
        highScoreText.text = highScore.ToString();
    }

    public void AddScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();

        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = playerScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
        }
		
    }

    public void PointSound()
    {
        pointSFX.Play();
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Pausebutton.SetActive(false);
        gameOverScreen.SetActive(true);
        mainBGMSound.Stop();
        deathSFX.Play();
    }

    public void PauseGame()
    {
        mainBGMSound.Pause();
        deathSFX.Pause();
        pointSFX.Pause();
        Pausebutton.SetActive(false);
        pauseOverScreen.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void ResumeGame()
    {
        mainBGMSound.UnPause();
        deathSFX.UnPause();
        pointSFX.UnPause();
        Pausebutton.SetActive(true);
        pauseOverScreen.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void GoHome()
    {
        ResumeGame();
        mainBGMSound.Stop();
        deathSFX.Stop();
        pointSFX.Stop();
        SceneManager.LoadScene("StartScene");
    }

    public void RestartGame()
    {
        ResumeGame();
        deathSFX.Stop();
        pointSFX.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
