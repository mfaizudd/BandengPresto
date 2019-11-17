using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;
using System;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    public int speed;
    public int score = 0;
    public int lives = 3;
    public bool moved = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI liveText;
    public GameObject explosion;

    public event Action Die;

    private bool isGameOver = false;

    //Awake 
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        if(!moved)
        {
            rb.velocity = new Vector2(moveHorizontal, transform.position.y) * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isGameOver) return;

        if(other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score : "+score;
        }
        else if (other.CompareTag("Enemy"))
        {
            var explosionObject = Instantiate(explosion, other.transform.position, other.transform.rotation);
            explosionObject.GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            Destroy(other.gameObject);
            lives--;
            liveText.text = "Lives : " + lives;
            if (lives <= 0)
            {
                StartCoroutine(GameOverDelay());
                isGameOver = true;  
                liveText.text = "Game Over";
                Die?.Invoke();
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }
}
