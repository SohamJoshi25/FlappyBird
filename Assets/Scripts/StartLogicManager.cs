using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLogicManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    public GameObject playButton;
    AudioSource cameraAudio;
    [SerializeField] private Slider volumeSlider;

    public void Start()
    {
        cameraAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);

        cameraAudio.volume = volumeSlider.value*0.5f;

        
        playButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
        cameraAudio.volume = volumeSlider.value*0.5f;
        PlayerPrefs.Save();
    }

    public void StartScene()
    {
        playButton.SetActive(false);
        Time.timeScale = 1;
    }

    public void ResetHS()
    {
        PlayerPrefs.SetInt("highscore", 0);
        PlayerPrefs.Save();
    }
    

}
