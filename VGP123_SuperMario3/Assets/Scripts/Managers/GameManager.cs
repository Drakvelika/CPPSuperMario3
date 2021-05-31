using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public int maxLives = 3;

    int _score = 0;
    public int score
    {
        get { return _score; }
        set 
        { 
            _score = value;
            Debug.Log("Current Score Is: " + _score);
        }
    }
    int _lives;
    public int lives
    {
        get { return _lives; }
        set
        {
            if (_lives > value)
            {
                Respawn();
            }
            _lives = value;

            if (_lives > maxLives)
            {
                _lives = maxLives;
            }
            else if (_lives < 0)
            {
                //Game Over code goes here.
            }
            Debug.Log("Current Lives Are: " + _lives);
        }
    }

    public GameObject playerinstance;
    public GameObject playerPrefab;
    public LevelManager currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        //SceneManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                SceneManager.LoadScene("TitleScreen");
            }    
            else if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        //SceneManager.LoadScene();
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            QuitGame();
        }
        if (_lives < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            _lives = maxLives;
            _score = 0;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
    EditorApplication.isPlaying = false;
#else
       Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void SpawnPlayer(Transform spawnLocation)
    {
        CameraFollow mainCamera = FindObjectOfType<CameraFollow>();
        EnemyTurret[] enemyTurrets = FindObjectsOfType<EnemyTurret>();
        if (mainCamera)
        {
            mainCamera.player = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
            playerinstance = mainCamera.player;
        }
        else
        {
            SpawnPlayer(spawnLocation);
        }

        for (int i = 0; i < enemyTurrets.Length; i++)
        {
            enemyTurrets[i].Player = playerinstance.transform;
        }
    }

    public void Respawn()
    {
        playerinstance.transform.position = currentLevel.spawnLocation.position;
    }
}
