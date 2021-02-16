using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public static int speedIndex;
    [SerializeField] float[] speedArr = new float[6] { 10f, 10f, 15f, 20f, 25f, 30f };

    public GameObject Platfrom;
    public bool IsStarted;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, -1);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        print(speedArr[speedIndex]);
        rb.velocity = rb.velocity.normalized * speedArr[speedIndex];
        if (!IsStarted)
        {
            transform.position = new Vector3(Platfrom.transform.position.x, transform.position.y, transform.position.z);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            IsStarted = true;
        }
    }
    public void startBall()
    {
        float randX = Random.Range(-3,3);
        Vector2 deriction = new Vector2(randX, 1);
        Vector2 force = deriction.normalized * speedArr[speedIndex];
        rb.velocity = force;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 255, 255, 1f);
        Gizmos.DrawRay(transform.position, rb.velocity);
    }

    public void Restart()
    {
        transform.position = new Vector3(Platfrom.transform.position.x, Platfrom.transform.position.y + 0.5f, Platfrom.transform.position.z);
        startBall();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //C определнной вероятностью, при ударе об стенку мяч меняет свою траекторию
        float correction = Random.Range(0, 7);
        if (collision.gameObject.CompareTag("border") && correction == 1)
        { 
            float randX = Random.Range(-5, 0);
            Vector2 deriction = new Vector2(randX, 1);
            Vector2 force = deriction.normalized * speedArr[speedIndex];
            rb.velocity = force;
        }
    }
}
