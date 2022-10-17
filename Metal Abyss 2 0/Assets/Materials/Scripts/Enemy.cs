using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float vel;
    Transform Player;
    public float dis;
    public int damage;
    bool IsLeft;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if (transform.position.x - Player.position.x < 0f && !IsLeft) Flip();
        if (transform.position.x - Player.position.x > 0f && IsLeft) Flip();
        if (Vector2.Distance(transform.position, Player.position) < dis)
        {
           transform.position = Vector2.MoveTowards(transform.position , Player.position , Time.deltaTime * vel);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player1>().Takehit(damage);
        }
    }
    void Flip()
    {
        IsLeft = !IsLeft;
        Vector3 A = transform.localScale;
        A.x *= -1;
        transform.localScale = A;
    }
}
