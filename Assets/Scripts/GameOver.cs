using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text gameText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + GameManager.score.ToString() + "/" + GameManager.maxScore.ToString();
        if(GameManager.maxScore  == GameManager.score) {
            gameText.text = "Game Won";
        }
        else {
            gameText.text = "Game Over";
        }
    }

}
