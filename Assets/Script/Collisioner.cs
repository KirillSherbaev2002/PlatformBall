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

    public Star StarScript;
    public Anti DarkStarScript;

    public int objectLives;
    public Sprite[] Icons = new Sprite[5];

    [Header("Импорт дропов")]
    public GameObject PickUpCristal;
    public GameObject DarkCristal;
    public GameObject YellowCristal;
    public GameObject BlueCristal;

    public GameObject EffectDestroied;

    public int level;

    public Collisioner[] NumberOfObjects;

    // Start is called before the first frame update
    void Start()
    {
        Points.pointsvalue = level;
        Reset();
    }

    public void Reset()
    {
        objectLives = Random.Range(0, 10);
        gameObject.GetComponent<SpriteRenderer>().sprite = Icons[objectLives];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        objectLives--; 
        if (objectLives < 0)
        {
            gameObject.SetActive(false);
        }
        BlockDestroyed();
    }
    public void BlockDestroyed()
    {
        //Во время уничтожения блока срабатывает...
        Instantiate(EffectDestroied, transform.position, Quaternion.identity);
        int option = Random.Range(0, 10);
        //70% вероятности 
        if (option < 6)
        {
            Instantiate(PickUpCristal, transform.position, Quaternion.identity);
            StarScript.SetStar();
        }
        //10% вероятности 
        if (option == 7)
        {
            Instantiate(DarkCristal, transform.position, Quaternion.identity);
            DarkStarScript.SetStar();
        }
        if (option == 8)
        {
            Instantiate(YellowCristal, transform.position, Quaternion.identity);
        }
        if (option == 9)
        {
            Instantiate(BlueCristal, transform.position, Quaternion.identity);
        }
        CheckWin();
    }
    public void CheckWin()
    {
        NumberOfObjects = FindObjectsOfType<Collisioner>();
        if (NumberOfObjects.Length == 0)
        {
            level++;
            if (level >= 6)
            {
                level = 5;
            }

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
