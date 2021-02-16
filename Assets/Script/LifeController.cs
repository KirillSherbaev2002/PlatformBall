using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        for (int i = 0; i < 3; i++)
        {
            if (lifes == i)
            {
                Destroy(Hearts[i]);
            }
        }
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
        if (lifes == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
