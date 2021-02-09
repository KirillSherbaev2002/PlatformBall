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
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lifes--;
        for (int f = 1; f >= 3; f++)
        {
            if(f > lifes)
            {
                Hearts[f].SetActive(true);
            }
            else
            {
                Hearts[f].SetActive(false);
            }
        }
        //if (lifes == 3)
        //{
        //    Hearts[0].SetActive(true);
        //    Hearts[1].SetActive(true);
        //    Hearts[2].SetActive(true);
        //}
        //if (lifes == 2)
        //{
        //    Hearts[0].SetActive(true);
        //    Hearts[1].SetActive(true);
        //    Hearts[2].SetActive(false);
        //}
        //if (lifes == 1)
        //{
        //    Hearts[0].SetActive(true);
        //    Hearts[1].SetActive(false);
        //    Hearts[2].SetActive(false);
        //}
        //if (lifes == 0)
        //{
        //    CurrentCanvas.SetActive(false);
        //    GameOverCanvas.SetActive(true);
        //    Platform.SetActive(false);
        //}
    }
    public void GameRest()
    {
        lifes = 3;
        CurrentCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        Platform.SetActive(true);
        ball.transform.position = new Vector3(0.05f, 3.5f, 0);

    }
}
