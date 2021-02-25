using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anti : MonoBehaviour
{
    [Header("Cristals Info")]
    public Sprite[] negativeCrystals = new Sprite[5];
    public int[] negativeEffect = new int[] { 20, 40, 80, 160, 320, 640 };
    public int negativeRandom;
    public float period;

    public Cristals cristals;

    [Header("Effects")]
    public GameObject VisualEffect;
    public void SetStar()
    {
        negativeRandom = Random.Range(0, negativeCrystals.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = negativeCrystals[negativeRandom];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cristals = FindObjectOfType<Cristals>();
            cristals.score = cristals.score - negativeEffect[negativeRandom];
            if (cristals.score < 0)
            {
                cristals.score = 0;
            }
            cristals.SetValue();
            Instantiate(VisualEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
