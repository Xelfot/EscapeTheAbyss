using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector2.left * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerRunner>().health -= damage;
            Destroy(gameObject);
        }
    }
}
