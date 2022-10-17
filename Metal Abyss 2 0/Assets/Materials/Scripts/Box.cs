using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Player1 P1;
    Rigidbody2D rb;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        P1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>();
    }
    private void OnTriggerEnter2D(Collider2D Color)
    {
       
        if (Color.gameObject.tag == "RedB" && this.name == "R")
        {
            P1.c++;
            transform.position = Color.gameObject.transform.position;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (Color.gameObject.tag == "GreenB" && this.name == "G")
        {
            P1.c++;
            transform.position = Color.gameObject.transform.position;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }      
        if (Color.gameObject.tag == "BlueB" && this.name == "B")
        {
            P1.c++;
            transform.position = Color.gameObject.transform.position;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (Color.gameObject.tag == "YellowB" && this.name == "Y")
        {
            P1.c++;
            transform.position = Color.gameObject.transform.position;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        Check();
    }

    private void Check()
    {
        if (P1.c >= 4 && P1.c % 4 == 0 )
        {
            GameObject.FindGameObjectWithTag("ExitRoom").GetComponent<Exit>().DoorOpen();
            P1.DoorOp.SetActive(true);



        }

    }
}
