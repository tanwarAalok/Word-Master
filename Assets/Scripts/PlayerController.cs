using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.01f;

    public float easySpeed = 0.005f;
    public TMP_Text scoreText;
   
    // Flap force
    public float force = 300;

    void Start () {    
        // Fly towards the right
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.y);
    }
   
    // Update is called once per frame
    void Update () {
        scoreText.text = "Score : " + GameManager.score.ToString();
      
        // Flap
        if (!TriggerController.wordGameStart && Input.GetKeyDown(KeyCode.Space)){
          GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }

        if(TriggerController.wordGameStart){
          transform.position = new Vector3(transform.position.x + easySpeed, 3.0f, transform.position.z);
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
