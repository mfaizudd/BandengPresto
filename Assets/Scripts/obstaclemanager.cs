using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleManager : MonoBehaviour {

    public GameObject[] obstacles;
    public Remover remover;
    public Button playButton;
    public Image img;
    public PlayerController player;
    public bool play = false;
    public TextMeshProUGUI highScoreText;
    public float enemyProbability = 30;

    float timeDelay = 2.0f;
    private float timestamp;

	// Use this for initialization
	void Start () {
        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        player.Die += Player_Die;
	}

    private void Player_Die()
    {
        playButton.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
        timeDelay = 2.0f;
        playButton.GetComponentInChildren<TextMeshProUGUI>().text = "Restart";
        if (player.score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", player.score);
            highScoreText.text = player.score.ToString();
        }
    }

    // Update is called once per frame
    void Update () {
        if(play)
        {
            if (timestamp < Time.time)
            {
                spawnObstacle();
                timeDelay = (timeDelay <= 0.5f) ? 0.5f : timeDelay - 0.05f;

                timestamp += timeDelay;
            }
        }
        else
        {
            playButton.gameObject.SetActive(true);
            img.gameObject.SetActive(true);
        }
	}

    public void Play()
    {
        var text = playButton.GetComponentInChildren<TextMeshProUGUI>().text;
        if(text=="Restart")
        {
            player.Restart();
        }
        else
        {
            playButton.gameObject.SetActive(false);
            img.gameObject.SetActive(false);
            player.lives = 3;
            play = true;
            player.liveText.text = "Lives : " + player.lives;
            player.score = 0;
            player.scoreText.text = "Score : " + player.score;
            timestamp = Time.time + timeDelay;
            Time.timeScale = 1;
        }
    }

    void spawnObstacle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-15f, 15f), transform.position.y, 27);

        //var enemyRoll = Random.Range(0, 100);
        //if(enemyRoll < enemyProbability && obstacles.Length > 1)
        //{
        //    Vector3 enemyPos = new Vector3(Random.Range(-15f, 15f), transform.position.y, 27);
        //    var enemy = obstacles[Random.Range(1, obstacles.Length)];
        //    Instantiate(enemy, enemyPos, transform.rotation);
        //}

        Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, transform.rotation);
    }

    private void OnDisable()
    {
        player.Die -= Player_Die;
    }
}
