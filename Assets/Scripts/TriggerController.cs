using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public static bool wordGameStart = false;
    public SpeakerController sc;

    void OnTriggerEnter2D(Collider2D coll) {
        wordGameStart = true;
        sc.playAudio();
        canvas.SetActive(wordGameStart);
    }

    void OnCollisionEnter2D(Collision2D other) {
        wordGameStart = false;
        canvas.SetActive(wordGameStart);
    }

}
