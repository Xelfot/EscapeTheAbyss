using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : MonoBehaviour
{
    GameObject Player;
    public int collisionDamage;
    public string collisionTag;
    public int damage = 1;
    public float speed;
    void Start()
    {

    }
   

    void Update()
    {
        transform.Translate(Vector2.left * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        


        if (collision.gameObject.tag == "Player")
        {
            PlayerRunner health = collision.gameObject.GetComponent<PlayerRunner>();
           health.RunHit(collisionDamage);
            Destroy(gameObject);
        }

    }
}
