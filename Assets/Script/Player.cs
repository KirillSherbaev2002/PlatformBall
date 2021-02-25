using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isAuto;

    [Header("Import")]
    public Ball ball;
    public Cristals cristals;
    public Star star;
    public Anti anti;

    [Header("Limitations")]
    public float MaxX;
    public float[] ScaleArr = new float[3] { -0.9f, 1, 1.1f};
    public int ScaleIndex;
	void Start()
    {
        cristals = FindObjectOfType<Cristals>();
        star = FindObjectOfType<Star>();
        anti = FindObjectOfType<Anti>();
	}
    void Update()
    {
		Vector3 newPadposition = new Vector3();
		//Создание нового Vector3, для передачи его автопилоту
		if (isAuto)
		{
            newPadposition = new Vector3(ball.transform.position.x, -3.78f, 0.84f);
		}
		else
		{
			Vector3 mousePixelPoint = Input.mousePosition;

			Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPoint);

			newPadposition = new Vector3(mouseWorldPosition.x, transform.position.y, 0);
		}
		newPadposition.x = Mathf.Clamp(newPadposition.x, -MaxX, MaxX);
		transform.position = newPadposition;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ball.startBall();
        }
    }
    public void ChangeScale()
    {
        ScaleIndex++;
        if (ScaleIndex == 3)
        {
            ScaleIndex = 0;
        }
        gameObject.transform.localScale = new Vector3 (ScaleArr[ScaleIndex], gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
