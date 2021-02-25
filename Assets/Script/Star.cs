using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [Header("Cristals Info")]
    public Sprite[] positiveCrystals = new Sprite[6];
    public int[] postiveEffect = new int[] { 20, 40, 80, 160, 320, 640 };
    public int positiveRandom;
    public float period;

    [Header("Effects")]
    public GameObject VisualEffect;

    public Cristals cristals;
    public void SetStar()
    {
        positiveRandom = Random.Range(0, positiveCrystals.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = positiveCrystals[positiveRandom];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cristals = FindObjectOfType<Cristals>();
            cristals.score = cristals.score + postiveEffect[positiveRandom];
            cristals.SetValue();
            Instantiate(VisualEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
