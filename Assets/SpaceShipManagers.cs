using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipManagers : MonoBehaviour
{
    public BetweenScenes BS;

    public SpriteRenderer BG;
    public Sprite[] BGImages = new Sprite[7];
    public int RandomNumber;

    public GameObject[] SpaceShips = new GameObject[3];
    void Start()
    {
        if(BS.SpaceShipIndex == 0)
        {
            SpaceShips[0].SetActive(true);
        }
        for (int i = 0; i < 3; i++)
        {
            if (BS.SpaceShipIndex == i)
            {
                SpaceShips[i].SetActive(true);
            }
            else
            {
                SpaceShips[i].SetActive(false);
            }
        }
        RandomNumber = Random.Range(0, 7);
        for (int i = 0; i < 7; i++)
        {
            BG.sprite = BGImages[i];
        }
    }
}
