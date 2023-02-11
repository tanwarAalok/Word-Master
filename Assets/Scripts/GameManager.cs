using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float level = 1;
    public static int score = 0;

    public static int maxScore = 2;

    public GameObject image = null;

    AudioSource audiosource;

    [SerializeField] AudioClip bgMusic_menu = null;
    [SerializeField] AudioClip bgMusic = null;
    [SerializeField] AudioClip gameOver_Music = null;
    [SerializeField] AudioClip gameWon_Music = null;
    [SerializeField] AudioClip collide_Music = null;

    public static bool playCollide = false;
    
    private void Start() {
        audiosource = GetComponent<AudioSource>();

        if(SceneManager.GetActiveScene().buildIndex < 2){
            PlayMenuMusic();
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            PlayGameMusic();
        }
        else{
            if(score != maxScore){
                GameOverMusic();
            }
            else GameWonMusic();
        }


        
        // else if(SceneManager.GetActiveScene().buildIndex <= 4 && SceneManager.GetActiveScene().buildIndex >= 2){
        //     PlayGameMusic();
        // }
    }

    private void Update() {
        if(playCollide){
            audiosource.clip = collide_Music;
            audiosource.Play();
            playCollide = false;
        }
    }


    public void PlayMenuMusic(){
        audiosource.clip = bgMusic_menu;
        audiosource.Play();
    }

    public void PlayGameMusic(){
        audiosource.clip = bgMusic;
        audiosource.Play();
    }
    
    public void GameOverMusic(){
        audiosource.clip = gameOver_Music;
        audiosource.Play();
    }

    public void GameWonMusic(){
        audiosource.clip = gameWon_Music;
        audiosource.Play();
    }

    


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
        level = 1.5f;
        LoadNextScene();
    }
    public void hardLevel()
    {
        level = 2;
        LoadNextScene();
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
        score = 0;
    }

    public void OpenHelp(){
        image.SetActive(true);
    }

    public void CloseHelp(){
        image.SetActive(false);
    }
}
