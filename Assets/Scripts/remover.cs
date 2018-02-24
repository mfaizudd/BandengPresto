using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remover : MonoBehaviour {


    public int lives = 3;
    public Text liveText;
    public bool gameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            lives--;
            liveText.text = "Lives : " + lives;
            if(lives<=0)
            {
                gameOver = true;

                liveText.text = "Game Over";
            }
        }
    }
}
