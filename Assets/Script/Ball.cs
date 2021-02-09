using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }
    public void startBall()
    {
        float randX = Random.Range(-3,3);
        Vector2 deriction = new Vector2(randX, 1);
        Vector2 force = deriction.normalized * speed;
        rb.velocity = force;
        print(rb.velocity);
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.DrawRay(transform.position, rb.velocity);
        }
    }
}
