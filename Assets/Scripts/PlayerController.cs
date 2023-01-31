using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;

    public float easySpeed = 0.005f;
   
    // Flap force
    public float force = 300;

    // Use this for initialization
    void Start () {    
        // Fly towards the right
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
   
    // Update is called once per frame
    void Update () {
        // Flap
        if (!TriggerController.wordGameStart && Input.GetKeyDown(KeyCode.Space)){
          GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }

        if(TriggerController.wordGameStart){
          transform.position = new Vector3(transform.position.x, 3.0f, transform.position.z);
          speed = easySpeed;
        }
        else speed = 2f;
    }

    void OnCollisionEnter2D(Collision2D coll) {
      // Restart
      if(coll.gameObject.CompareTag("Obstacle")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }

    }
}
