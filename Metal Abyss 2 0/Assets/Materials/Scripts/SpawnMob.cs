using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    public GameObject[] Enemies;
    public float time;
    public float amount;
    public float distante;
    Transform Player;
    public int damage;
    public float MaxTime;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
       

        if (amount > 0)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        if (Vector2.Distance(transform.position, Player.position) < distante)
        {
          if (time <= 0)
          {
               
                Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform.position, transform.rotation);
              amount = amount - 1;
              time = MaxTime;
          }
          else
          {
               time -= Time.deltaTime;
          }
        
        }

       
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player1>().Takehit(damage);
        }
    }
}
