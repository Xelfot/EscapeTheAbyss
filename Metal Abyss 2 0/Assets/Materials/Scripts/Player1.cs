using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public float StartDashCd;
    float DashCd;
    public int c = 0;
    public static List<string> spawnPositions = new List<string>();
    public GameObject[] Batary;
    public int hp;
    public int maxhp;
    Rigidbody2D rb;
    public Joystick joy; 
    public Joystick Attackjoy;
    public GameObject DoorOp;
   
    public Animator anim;
    bool hit = true;
   
    //bool FaceRight = true;

    
    void Start()
    {
        
        DashCd = StartDashCd;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
    public Vector2 moveVector;
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Dash();
        }
        if (DashCd > 0)
        {
            DashCd -= Time.deltaTime;
        }
            Walk();


            
         
            if (joy.Horizontal < 0 || Attackjoy.Horizontal < 0/*&& FaceRight*/)
            {
                Flip();
            }
            else if (joy.Horizontal > 0 || Attackjoy.Horizontal > 0/*&& !FaceRight*/)
            {
                Flip();

            }
        
           



    }
    int count = 0;
    void FixedUpdate()
    {
        count++;
        if (count == 250)
            print(Player1.spawnPositions.Count);
    }

    void Flip()
    {
        //FaceRight = !FaceRight;
        /* Vector3 A = transform.localScale;
         A.x *= -1;

         transform.localScale = A;*/
        if (joy.Horizontal > 0 || Attackjoy.Horizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (joy.Horizontal < 0 || Attackjoy.Horizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void Walk()
    {

       
        if (Mathf.Abs(moveVector.x) > 0.1 || Mathf.Abs(moveVector.y) > 0.1)
        {
          anim.SetInteger("idle" , 1);
           
        }
        else
        {
            anim.SetInteger("idle", 0);
        
        }
        moveVector.x = joy.Horizontal;
        moveVector.y = joy.Vertical;
        transform.position = Vector2.Lerp(transform.position, transform.position + new Vector3(moveVector.x, moveVector.y) * 4f, Time.deltaTime * 2);

    }


    public void Takehit(int damage)
    {
        //StartCoroutine(Splash());
        if (hit == true)
        {
        if (hp > 0)
        {
            Batary[3 - hp].SetActive(false);



        }
            StartCoroutine(HitCD());
            StartCoroutine(Blinck());

            hp -= damage;


        if (hp > 0)
        {
            Batary[3 - hp].SetActive(true);



        }

        if (hp <= 0)
        {
                GetComponent<Collider2D>().enabled = false;
                this.enabled = false;
                panel.SetActive(true);
                Physics2D.IgnoreLayerCollision(8, 6, false);
            }
     }
    }
    public GameObject panel;

   IEnumerator HitCD()
    {
        hit = false;
      
        yield return new WaitForSeconds(1f);
        hit = true;
       

    }
    IEnumerator Blinck()
    {
        if (hit == false)
        {
            Color invisible = new Color(255, 255, 255, 0);
            this.GetComponent<SpriteRenderer>().color = invisible;
            yield return new WaitForSeconds(0.25f);
            Color visible = new Color(255, 255, 255, 255);
            this.GetComponent<SpriteRenderer>().color = visible;
        }
    }
    /*IEnumerator Splash()
    {
        Physics2D.IgnoreLayerCollision(8, 6, true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(8, 6, false);
    }*/

    public void Dash()
    {
        if (DashCd > 0)
        {
            return;
        }
        rb.AddForce(moveVector * 3f, ForceMode2D.Impulse);
        anim.SetTrigger("Dash");
        DashCd = StartDashCd;
    }








}

