using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TMP_Text[] PointsTMP = new TMP_Text[2];
    public static int pointsvalue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdatePoints()
    {
        PointsTMP[0].text = pointsvalue.ToString() + " years";
        PointsTMP[1].text = pointsvalue.ToString() + " years";
    }
}
