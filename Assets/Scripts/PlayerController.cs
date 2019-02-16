using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    public int speed;
    public int score = 0;
    public int lives = 3;
    public Text scoreText;
    public bool moved = false;
    public Text liveText;

    //Awake 
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if(!moved)
        {
            rb.velocity = new Vector2(moveHorizontal, transform.position.y) * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score : "+score;
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            lives--;
            liveText.text = "Lives : " + lives;
            if (lives <= 0)
            {
                liveText.text = "Game Over";
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
