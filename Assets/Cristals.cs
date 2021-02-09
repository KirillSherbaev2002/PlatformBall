using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cristals : MonoBehaviour
{
    public int score;
    private void Start()
    {
        SetValue();
    }
    public void SetValue()
    {
        gameObject.GetComponent<TMP_Text>().text = score + " Crystals";
    }
}
