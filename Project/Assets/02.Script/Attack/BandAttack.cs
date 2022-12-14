using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandAttack : MonoBehaviour
{
    float time = 0.01f;
    public float SleepTime = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Monster monster = collision.GetComponent<Monster>();
            monster.SturnTime += SleepTime;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
