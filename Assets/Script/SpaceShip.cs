using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SpaceShip : MonoBehaviour
{
    [Header("StarshipInfo")]
    [SerializeField] int IndexSpaceShip;
    public Sprite[] SpaceShips = new Sprite[3];
    public Sprite[] SpaceShipsUnActive = new Sprite[3];
    public Image SpaceShipImageHolder;
    public bool[] IsPurchased = new bool[3] { true, false, false };
    public int[] prices = new int[3];

    [Header("ScoreInfo")]
    public TMP_Text scoreTMP;
    public int score;

    [Header("Others")]
    public BetweenScenes BS; 
    void Start()
    {
        #region IsShipPurchased
        for (int i = 0; i<3; i++)
        {
            if (PlayerPrefs.GetInt("IsShipPurchased" + i.ToString()) == 1)
            {
                IsPurchased[i] = true;
            }
            else
            {
                IsPurchased[i] = false;
            }
        }
        #endregion
        ShowCurrentIcon();
        UpdateScore();
    }

    public void TurnRight()
    {
        IndexSpaceShip++;
        if (IndexSpaceShip >= 3)
        {
            IndexSpaceShip = 0;
        }
        ShowCurrentIcon();
    }

    public void TurnLeft()
    {
        IndexSpaceShip--;
        if (IndexSpaceShip < 0)
        {
            IndexSpaceShip = 2;
        }
        ShowCurrentIcon();
    }

    public void TryPurchase()
    {
        if (score >= prices[IndexSpaceShip] && IsPurchased[IndexSpaceShip] == false)
        {
            score = score - prices[IndexSpaceShip];
            PlayerPrefs.SetInt("score", score);
            UpdateScore();
            IsPurchased[IndexSpaceShip] = true;
            ShowCurrentIcon();

            #region ShipIsPurchased
            PlayerPrefs.SetInt("IsShipPurchased" + IndexSpaceShip, 1);
            #endregion
        }
    }
    void ShowCurrentIcon()
    {
        if (IsPurchased[IndexSpaceShip] == true)
        {
            SpaceShipImageHolder.GetComponent<Image>().sprite = SpaceShips[IndexSpaceShip];
            BS.SpaceShipIndex = IndexSpaceShip;
}
        else
        {
            SpaceShipImageHolder.GetComponent<Image>().sprite = SpaceShipsUnActive[IndexSpaceShip];
        }
        MessegeToSO();
    }
    void UpdateScore()
    {
        score = PlayerPrefs.GetInt("score");
        scoreTMP.text = score.ToString();
    }
    void MessegeToSO()
    {
        BS.SpaceShipIndex = IndexSpaceShip;
        DontDestroyOnLoad(this);
    }
    public void ToGameScene()
    {
        SceneManager.LoadScene(0);
    }
}
