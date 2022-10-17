using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
   
    Animator anim;
    public int bossHp = 60;
    public GameObject Energy;
    public GameObject Hp1;
    public GameObject Hp2;
    public GameObject Hp3;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeHit(int damage)
    {
        bossHp -= damage;
        CheckHealth();

    }

   
    void CheckHealth()
    {
        if (bossHp <= 40 && Hp3.activeSelf == true)
        {
            Hp3.SetActive(false);
            Laser();
        }
        else if (bossHp == 30)
        {
            bossHp = bossHp - 1;
            Laser();
        }
       else if (bossHp <= 20 && Hp2.activeSelf == true)
        {
            Hp2.SetActive(false);
            Laser();
        } 
       else if (bossHp == 10 )
        {
            bossHp = bossHp - 1;
            Laser();
        } 
       
       else if (bossHp <= 0 && Hp1.activeSelf == true)
        {
            Destroy(gameObject);
            Hp1.SetActive(false);
        }
    }
    void Laser()
    {
        Instantiate(Energy);
        anim.SetTrigger("Blaser");
    }
}
