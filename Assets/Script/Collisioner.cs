using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisioner : MonoBehaviour
{
    [Header("О блоке")]
    public GameObject PointsHolder;
    public Points Points;

    public int objectLives;
    public Sprite[] Icons = new Sprite[5];

    public GameObject PickUpCristal;
    public GameObject EffectDestroied;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        objectLives = Random.Range(0, 5);
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
        if (objectLives <= 0)
        {
            Points.pointsvalue += 1000;
            gameObject.SetActive(false);
            Points.UpdatePoints();
        }
        ToCorrectImage();
        BlockDestroyed();
    }
    public void BlockDestroyed()
    {
        Instantiate(EffectDestroied, transform.position, Quaternion.identity);
        Instantiate(PickUpCristal, transform.position, Quaternion.identity);
    }
}
