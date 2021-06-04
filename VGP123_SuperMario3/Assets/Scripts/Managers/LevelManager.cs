using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Startinglives;
    public Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.lives = Startinglives;
        GameManager.instance.SpawnPlayer(spawnLocation);
        GameManager.instance.currentLevel = GetComponent<LevelManager>();
    }
}
