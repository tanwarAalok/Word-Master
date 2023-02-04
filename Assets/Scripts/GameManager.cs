using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int level = 1;
    public static int score = 0;


    public static void LoadNextScene()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(levelIndex);
    }

    public void easyLevel()
    {
        level = 1;
        LoadNextScene();
    }
    public void mediumLevel()
    {
        level = 2;
        LoadNextScene();
    }
    public void hardLevel()
    {
        level = 3;
        LoadNextScene();
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
        score = 0;
    }
}
