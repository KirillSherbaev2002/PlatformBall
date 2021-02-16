using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TMP_Text PointsTMP;
    public static int pointsvalue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdatePoints()
    {
        PointsTMP.text = "THE AGE OF CIVILIZATION: "+ pointsvalue + " level";
    }
}
