using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collisioner : MonoBehaviour
{
    [Header("О блоке")]
    public GameObject PointsHolder;
    public Points Points;

    public int objectLives;
    public Sprite[] Icons = new Sprite[5];

    public GameObject PickUpCristal;
    public GameObject DarkCristal;
    public GameObject EffectDestroied;

    public int level;

    public Collisioner[] NumberOfVulkans;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("level");

        Points.pointsvalue = level;
        Points.UpdatePoints();

        Reset();
    }

    public void Reset()
    {
        objectLives = Random.Range(0, level);
        gameObject.GetComponent<SpriteRenderer>().sprite = Icons[objectLives];
    }

    public void ToCorrectImage()
    {
        for(int i = 0; i < 5; i++)
        {
            if (objectLives == i)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Icons[i];
            }
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        objectLives--; 
        if (objectLives < 0)
        {
            gameObject.SetActive(false);
        }
        ToCorrectImage();
        BlockDestroyed();
    }
    public void BlockDestroyed()
    {
        Instantiate(EffectDestroied, transform.position, Quaternion.identity);
        int option = Random.Range(0, 10);
        //Если 0-3 вкл. - ничего не падает 
        if (option >3 && option <7)
        {
            Instantiate(PickUpCristal, transform.position, Quaternion.identity);
        }
        if (option == 7)
        {
            Instantiate(DarkCristal, transform.position, Quaternion.identity);
        }
        CheckWin();
    }
    public void CheckWin()
    {
        NumberOfVulkans = FindObjectsOfType<Collisioner>();
        if (NumberOfVulkans.Length == 0)
        {
            level++;
            if (level >= 6)
            {
                level = 5;
            }

            Points.pointsvalue = level;
            Points.UpdatePoints();

            PlayerPrefs.SetInt("level", level);
            SceneManager.LoadScene(0);

            Ball.speedIndex = level;
        }
    }
    public void BackToStartLevel()
    {
        level = 1;
        PlayerPrefs.SetInt("level", level);
        Points.pointsvalue = level;
        Points.UpdatePoints();
        SceneManager.LoadScene(0);
    }
}
