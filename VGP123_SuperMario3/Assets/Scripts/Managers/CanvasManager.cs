using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;
    public Button backButton;
    public Button settingsButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    [Header("Text")]
    public Text scoreText;
    public Text volText;

    [Header("Sprites")]
    public Image heart1;
    public Image heart2;
    public Image heart3;

    [Header("Slider")]
    public Slider volSlider;

    public Toggle muteButton;

   // public Image[] Hearts;

    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame());
        }
        if (quitButton)
        {
            quitButton.onClick.AddListener(() => GameManager.instance.QuitGame());
        }
        if (returnToGameButton)
        {
            returnToGameButton.onClick.AddListener(() => ReturnToGame());
        }
        if (returnToMenuButton)
        {
            returnToMenuButton.onClick.AddListener(() => GameManager.instance.ReturnToMenu());
        }
        if (backButton)
        {
            backButton.onClick.AddListener(() => ShowMainMenu());
        }
        if (settingsButton)
        {
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());
        }
        if (scoreText)
        {
            if (GameManager.instance)
            {
                scoreText.text = GameManager.instance.score.ToString();
            }
            else
            {
                SetScoreText();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        if (settingsMenu)
        {
            if (settingsMenu.activeSelf)
            {
                volText.text = Mathf.Round(volSlider.value).ToString();
            }
        }
    }

    void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        Debug.Log("hi");
        Time.timeScale = 1;
    }

    void ShowMainMenu()
    {
        if (SceneManager.GetActiveScene().name == "TitleScreen")
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 1;
        }
    }

    void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        if (pauseMenu)
        pauseMenu.SetActive(false);
    }

    public void SetLivesText()
    {
        if (GameManager.instance)
        {
            switch (GameManager.instance.lives)
            {
                case 3:
                    heart1.enabled = true;
                    heart2.enabled = true;
                    heart3.enabled = true; 
                    break;
                case 2:
                    heart3.enabled = false;
                    heart2.enabled = true;
                    heart1.enabled = true;
                    break;
                case 1:
                    heart2.enabled = false;
                    heart1.enabled = true;
                    break;
                case 0:
                    heart1.enabled = false;
                    break;
            }
        }
    }
    public void SetScoreText()
    {
        if (GameManager.instance)
        {
            scoreText.text = GameManager.instance.score.ToString();
        }
    }
}
