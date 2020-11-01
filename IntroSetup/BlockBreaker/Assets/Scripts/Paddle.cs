using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPositionX = 1f;
    [SerializeField] float maxPositionX = 15f;

    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        Debug.Log("Paddle::Game session " + gameSession + " !");
        //if (!gameSession)
        //{
        //    gameSession = FindObjectOfType<GameStatus_Invisible_level>();
        //}
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minPositionX, maxPositionX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            float mousePositionX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            return mousePositionX;
        }
    }
}
