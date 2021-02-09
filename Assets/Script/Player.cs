using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	float yposition;

	public bool isStarted;

    public Ball ball;

	public float MaxX;
	void Start()
    {
		//ball = FindObjectOfType<ball>();
		//Нахождение обьекта типа ball
		yposition = transform.position.y;
	}
    void Update()
    {
		Vector3 newPadposition = new Vector3();
		//Создание нового Vector3, для передачи его автопилоту
		if (isStarted)
		{
			//newPadposition = new Vector3(ball.transform.position.x, yposition, 0);
			//Передача Vector3 расположения мяча
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
        ball.startBall();
    }
}
