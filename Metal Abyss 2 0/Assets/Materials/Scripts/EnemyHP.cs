using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int health;

    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(Blink());
        health -= damage;
    }
    IEnumerator Blink()
    {
        Color invisible = new Color(255, 255, 255, 0);
        this.GetComponent<SpriteRenderer>().color = invisible;
        yield return new WaitForSeconds(0.25f);
        Color visible = new Color(255, 255, 255, 255);
        this.GetComponent<SpriteRenderer>().color = visible;

    }
}
