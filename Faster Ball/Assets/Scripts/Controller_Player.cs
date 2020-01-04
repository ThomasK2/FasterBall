using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    //Variables
    public float moveSpeed = 25;
    public GameObject player;

    private Rigidbody2D playerBody;
    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > screenWidth / 2)
                RunPlayer(1.0f);

            if (Input.GetTouch(i).position.x < screenWidth / 2)
                RunPlayer(-1.0f);

            ++i;
        }
    }

    void FixedUpdate()
    {
        #if UNITY_EDITOR
        RunPlayer(Input.GetAxis("Horizontal"));
        #endif
    }

    //The fucking move player
    private void RunPlayer(float horizontalPlayer)
    {
        playerBody.AddForce(new Vector2(horizontalPlayer * moveSpeed * Time.deltaTime, 0));
    }
}
