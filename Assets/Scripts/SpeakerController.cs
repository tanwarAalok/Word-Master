using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerController : MonoBehaviour
{
    [SerializeField] Button speaker = null;

    [SerializeField] Sprite closedSpeakerSprite = null;
    [SerializeField] Sprite openSpeakerSprite = null;
    [SerializeField] TMP_InputField wordInput;

    public AudioClip[] spellingsAudio;
    public string[] spellings;

    AudioSource audiosource;

    void Start() {
        audiosource = GetComponent<AudioSource>();
    }

    void Update() {
        if(audiosource.isPlaying){
            speaker.image.sprite = openSpeakerSprite;
        }
        else speaker.image.sprite = closedSpeakerSprite;
    }

    public void playAudio()
    {
        audiosource.clip = spellingsAudio[GameManager.score];
        audiosource.Play();
    }


    public void speakerToggle(){
        if(speaker.image.sprite == closedSpeakerSprite){
            speaker.image.sprite  = openSpeakerSprite;
            playAudio();
        }
        else if(speaker.image.sprite == openSpeakerSprite){
            speaker.image.sprite  = closedSpeakerSprite;
            audiosource.Stop();
        }
    }

    public void wordSubmitted(){
        int index = GameManager.score;
        if(wordInput.text == spellings[index]){
            Debug.Log("Correct");
        }
    }
}
