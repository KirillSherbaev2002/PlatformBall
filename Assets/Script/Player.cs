using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float yposition;

    public bool isAuto;

    public Ball ball;
    public Cristals cristals;

    public float MaxX;

    public float[] ScaleArr = new float[3] { -0.9f, 1, 1.1f};
    public int ScaleIndex;
	void Start()
    {
        cristals = FindObjectOfType<Cristals>();
        yposition = transform.position.y;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            cristals.score++;
            cristals.SetValue();
        }
        if (collision.gameObject.CompareTag("DarkStar"))
        {
            cristals.score = cristals.score - 10;
            if (cristals.score < 0)
            {
                cristals.score = 0;
            }
            cristals.SetValue();
        }
        if (collision.gameObject.CompareTag("YellowStar"))
        {
            int YellowRandom = Random.Range(0, 2);
            if (YellowRandom == 0)
            {
                ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            if (YellowRandom == 1)
            {
                ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            if (YellowRandom == 1)
            {
                ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
        if (collision.gameObject.CompareTag("BlueStar"))
        {
            int BlueRandom = Random.Range(0, 2);
            if (BlueRandom == 0)
            {
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            if (BlueRandom == 1)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            if (BlueRandom == 2)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        Destroy(collision.gameObject);
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
