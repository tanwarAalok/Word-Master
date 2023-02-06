using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float speed = 2f;

    private float wordGameSpeed = 0.5f;

    public TMP_Text scoreText;
   
    // Flap force
    public float force = 300;

    private void Start() {
      speed = speed * GameManager.level;
      wordGameSpeed = wordGameSpeed * GameManager.level;
    }
   
    // Update is called once per frame
    void Update () {
        scoreText.text = "Score : " + GameManager.score.ToString();
      
        // Flap
        if (!TriggerController.wordGameStart && Input.GetKeyDown(KeyCode.Space)){
          GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }

        if(TriggerController.wordGameStart){
          transform.Translate(Vector2.right * wordGameSpeed * Time.deltaTime);
          transform.position = new Vector3(transform.position.x , 3.0f, transform.position.z);
          GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else {
          transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
      if(coll.gameObject.CompareTag("Obstacle")){
        GameManager.LoadNextScene();
      }

    }

}
