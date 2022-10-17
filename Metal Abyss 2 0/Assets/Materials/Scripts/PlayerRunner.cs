using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public GameObject[] Batary;
    public int health;
    public int maxhp;
    public float speed;
    public float maxHeight;
    public float minHeight;
    bool hit = true;

    public void MoveUp()
    {
        if (transform.position.y >= maxHeight)
        {
            return;
        }
        targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
    }
    public void MoveDown()
    {
        if (transform.position.y <= minHeight)
        {
            return;
        }
        targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
    }
    private void Start()
    {
        for (int i = 0; i < Batary.Length; i++)
        {
            if (i == 0)
            {
                Batary[i].SetActive(true);
            }
            else
            {
                Batary[i].SetActive(false);
            }

        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

      
    }
        public void RunHit(int damage)
        {
            if (hit == true)
            {
                if (health > 0)
                {
                    Batary[3 - health].SetActive(false);



                }
                StartCoroutine(HitCD());
                

                health -= damage;


                if (health > 0)
                {
                    Batary[3 - health].SetActive(true);



                }

                if (health <= 0)
                {
                GetComponent<Collider2D>().enabled = false;
                this.enabled = false;
                panel.SetActive(true);
                }
            }
        } 
    

    IEnumerator HitCD()
    {
        hit = false;
        yield return new WaitForSeconds(1f);
        hit = true;


    }

    public GameObject panel;
}

