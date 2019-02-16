using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirectionButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public int direction = 0;
    public GameObject player;

    private bool move = false;
    private Rigidbody2D rb;
    private PlayerController playerController;
    private float inputValue = 0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        move = true;
        playerController.moved = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        move = false;
        playerController.moved = false;
    }

    // Use this for initialization
    void Start () {
        rb = player.GetComponent<Rigidbody2D>();
        playerController = (PlayerController)player.GetComponent("PlayerController");
    }

    // Update is called once per frame
    void Update () {
		if(move)
        {
            inputValue += Time.deltaTime * direction;
            inputValue = Mathf.Clamp(inputValue, -1, 1);
            Debug.Log(rb.velocity);
            rb.velocity = new Vector2(inputValue, player.transform.position.y) * playerController.speed;
        }
        else
        {
            inputValue = 0f;
        }
    }
}
