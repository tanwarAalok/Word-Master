using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public static bool wordGameStart = false;
    public SpeakerController sc;

    public void WordGameStart(bool value){
        wordGameStart = value;
        canvas.SetActive(wordGameStart);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        WordGameStart(true);
        sc.playAudio();
    
    }

    void OnCollisionEnter2D(Collision2D other) {
        WordGameStart(false);
    }

}
