using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameObject[] Hearts = new GameObject[3];
    int lifes = 3;
    public GameObject GameOverCanvas;
    public GameObject CurrentCanvas;
    public GameObject Platform;

    public Ball ball;

    public Vector3 DefaultBallPostion;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            lifes--;
            ball.Restart();
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
        }
    }
}
