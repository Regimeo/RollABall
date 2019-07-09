using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text scoreText;
    public Text livesText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetAllText ();
        winText.text = "";
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

        if (Input.GetKey("escape"))
         Application.Quit();
    }

        void OnTriggerEnter(Collider other) 
    {
     if (other.gameObject.CompareTag("Pick Up"))
     {
          other.gameObject.SetActive(false);
          count = count + 1; 
          score = score + 1;
          SetAllText();
     }
     else if (other.gameObject.CompareTag("Enemy"))
     {
          other.gameObject.SetActive(false);
          count = count + 1;
          lives = lives - 1;
          SetAllText();
     }
     if (score == 12)
     {
     transform.position = new Vector3(45.0f, transform.position.y,0.0f); 
     }
     if (lives == 0)
     {
         Destroy(this);
         winText.text = "GAME OVER";
     }
    }

    void SetAllText ()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        if (score >= 24)
        {
            winText.text = ("You Win!");
        }

    }
}
