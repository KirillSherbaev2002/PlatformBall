using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GenerateScene : MonoBehaviour
{
    public GameObject[] Stars = new GameObject[3];
    public TMP_Text[] Names = new TMP_Text[3];
    public Color[] StarColors = new Color[7];
    public string[] TwoSymbols = new string[10] { "AU", "BM", "RC", "DC", "VO", "QI", "PO", "JH", "KE", "BM" };
    // Start is called before the first frame update
    void Start()
    {
        StarsVisualization();
    }

    // Update is called once per frame
    void Update()
    {
        //SceneManager.LoadScene(0);
    }

    void StarsVisualization()
    {
        for(int i = 0; i < 3; i++)
        {
            int currentIndex = Random.Range(1000, 9999);
            int currentColorIndex = Random.Range(0, 6);
            int currentSymbolsIndex = Random.Range(0, 10);
            Stars[i].GetComponent<Image>().color = StarColors[currentColorIndex];
            Names[i].text = TwoSymbols[currentSymbolsIndex] + currentIndex.ToString();
        }
    }
}
