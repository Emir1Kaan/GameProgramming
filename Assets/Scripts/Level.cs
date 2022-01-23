using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public int enemiesCount = 0;
    [SerializeField] GameObject[] enemies;


    public bool playerFailCheck = false;

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesCount = enemies.Length;
    }


    private void Update() {
        if(enemiesCount == 0 && SceneManager.GetActiveScene().buildIndex != 2)
        {
            nextLevel();
        }
        else if(enemiesCount == 0 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            MainMenu();
        }
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);        
    }

    public void resumeGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.levelIndex);
    }

}
