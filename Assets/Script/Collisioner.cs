using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisioner : MonoBehaviour
{
    public GameObject PointsHolder;
    public Points Points;

    public int objectLives;
    public Sprite[] Icons = new Sprite[5];
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
    }
}
