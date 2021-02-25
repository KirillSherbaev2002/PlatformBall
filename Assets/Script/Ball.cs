using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Main ball info")]
    public Rigidbody2D rb;
    public static int speedIndex;
    [SerializeField] float[] speedArr = new float[6] { 10f, 10f, 15f, 20f, 25f, 30f };

    public GameObject Platfrom;
    public bool IsStarted;

    [Header("AntiStop")]
    public Vector3 CheckPosition;
    public float TimeCheck;
    public GameObject BorderCollisionEffect;
    public Vector2 CheckDirection;
    public int timesOfSameDirection;
    [Header("Взрывные")]
    public bool isExploide;
    public float Radius;

    [Header("Аудио")]
    public AudioSource Bing;
    void Start()
    {
        rb.velocity = new Vector2(0, -1);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
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
        #region AntiStopForBall
        if (transform.position == CheckPosition && IsStarted == true)
        {
            TimeCheck++;
            if (TimeCheck >= 20)
            {
                Restart();
                TimeCheck = 0;
            }
        }
        else
        {
            TimeCheck = 0;
            CheckPosition = transform.position;
        }
        #endregion
    }
    public void startBall()
    {
        float randX = Random.Range(-3, 3);
        Vector2 deriction = new Vector2(randX, 1);
        Vector2 force = deriction.normalized * speedArr[speedIndex];
        rb.velocity = force;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, rb.velocity);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

    public void Restart()
    {
        transform.position = new Vector3(Platfrom.transform.position.x, Platfrom.transform.position.y + 2f, Platfrom.transform.position.z);
        startBall();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        //C определнной вероятностью, при ударе об стенку мяч меняет свою траекторию
        if (collision.gameObject.CompareTag("border"))
        {
            if (CheckDirection == rb.velocity || CheckDirection == -rb.velocity)
            {
                timesOfSameDirection++;
                if (timesOfSameDirection >= 4)
                {
                    float randX = Random.Range(-5, 0);
                    Vector2 deriction = new Vector2(randX, 1);
                    Vector2 force = deriction.normalized * speedArr[speedIndex];
                    rb.velocity = force;
                }
            }
            if (CheckDirection != rb.velocity)
            {
                CheckDirection = rb.velocity;
            }
        }
        if (collision.gameObject.CompareTag("border") || collision.gameObject.CompareTag("Collisioner"))
        {
            Instantiate(BorderCollisionEffect, transform.position, Quaternion.identity);
            float correction = Random.Range(0, 4);
            if (collision.gameObject.CompareTag("border") && correction == 1)
            {
                Bing.Play();
                float randX = Random.Range(-5, 0);
                Vector2 deriction = new Vector2(randX, 1);
                Vector2 force = deriction.normalized * speedArr[speedIndex];
                rb.velocity = force;
            }
            Exploide();
        }
        void ActiveExplode()
        {
            isExploide = true;
        }
        void Exploide()
        {
            int layerMask = LayerMask.GetMask("blocks");
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Radius, layerMask);
            foreach (Collider2D col in colliders)
            {
                Collisioner block = GetComponent<Collisioner>();
                if (block == null)
                {
                    Destroy(gameObject);
                }
                else
                {
                    block.BlockDestroyed();
                }
            }
        }
    }
}
