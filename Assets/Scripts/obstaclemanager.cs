using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obstaclemanager : MonoBehaviour {

    public GameObject obstacle;
    public remover r;
    public Button b;
    public Image img;
    public PlayerController player;
    public bool play = false;
    public Text highScoreText;

    float timeDelay = 2.0f;
    private float timestamp;

	// Use this for initialization
	void Start () {
        b.onClick.AddListener(TaskOnClick);
        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if(play)
        {
            if (player.lives<=0)
            {
                b.gameObject.SetActive(true);
                img.gameObject.SetActive(true);
                timeDelay = 2.0f;
                if (player.score > PlayerPrefs.GetInt("highScore", 0)) {
                    PlayerPrefs.SetInt("highScore", player.score);
                    highScoreText.text = player.score.ToString();
                }
            }
            else
            {
                if (timestamp < Time.time)
                {
                    spawnObstacle();
                    timeDelay = (timeDelay <= 0.5f) ? 0.5f : timeDelay - 0.05f;

                    timestamp += timeDelay;
                }
            }
        }
        else
        {
            b.gameObject.SetActive(true);
            img.gameObject.SetActive(true);
        }
	}

    void TaskOnClick()
    {
        b.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        player.lives = 3;
        play = true;
        player.liveText.text = "Lives : " + player.lives;
        player.score = 0;
        player.scoreText.text = "Score : " + player.score;
        timestamp = Time.time + timeDelay;
    }

    void spawnObstacle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-15f, 15f), transform.position.y, 27);
        Instantiate(obstacle, spawnPos, transform.rotation);
    }
}
