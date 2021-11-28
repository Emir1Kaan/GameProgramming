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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Level1");
    }

}
