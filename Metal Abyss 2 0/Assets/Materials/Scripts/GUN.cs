using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GUN : MonoBehaviour
{
    [SerializeField] private float AdditionalDeg = 0;
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    bool FaceRight = true;
    public Joystick Attackjoy;
   
    void Start()
    {

    }


    void Update()
    {
        if (Attackjoy.Horizontal < 0 && FaceRight)
        {
            Flip();
        }
        else if (Attackjoy.Horizontal > 0 && !FaceRight)
        {
            Flip();

        }
        if (Attackjoy.Horizontal == 0 && Attackjoy.Vertical == 0)
        {
            return;
        }
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                //Vector3 Dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                Vector3 Dir = new Vector3(Attackjoy.Horizontal, Attackjoy.Vertical, -9.99f);
                Debug.Log(Dir);
                float Angle = 0;
                if (transform.parent.transform.localScale.x > 0)
                {
                    Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;
                   
                }
                else
                {
                    Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;

                   
                }
               // Instantiate(bullet, shotPoint.transform.position, Quaternion.Euler(new Vector3(Attackjoy.Horizontal, Attackjoy.Vertical, 0)));
                Instantiate(bullet, shotPoint.transform.position, Quaternion.AngleAxis(Angle, Vector3.forward));
                /*if (transform.parent.transform.localScale.x > 0)
                {
                    Instantiate(bullet, shotPoint.position, transform.localRotation);
                }

                else
                {
                    Debug.Log(transform.rotation.z);
                    GameObject Bullet = Instantiate(bullet, shotPoint.position, new Quaternion(transform.rotation.x , transform.rotation.y , transform.rotation.z + 180 , transform.rotation.w));
                    //Bullet.transform.Rotate(transform.rotation.x , transform.rotation.y , transform.rotation.z) ;
                }*/
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
    private void FixedUpdate()
    {
        if (Attackjoy.Horizontal == 0 && Attackjoy.Vertical == 0)
        {
            return;
        }
        Vector3 Dir = new Vector3(Attackjoy.Horizontal, Attackjoy.Vertical, -9.99f);
       //Vector3 Dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        // print(Dir.y + " " + Dir.x);
        float Angle = 0;
        if (transform.parent.transform.localScale.x > 0)
        {
            Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;
           /* if (Mathf.Abs(Angle) >= 90 && Mathf.Abs(Angle) <= 180)
            {
                if (transform.localScale.y > 0)
                {
                    Flip();
                }

            }
            else
            {
                if (transform.localScale.y < 0)
                {
                    Flip();
                }
            }*/
        }
        else
        {
            Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg + 180;

            /*if (angle >= 90 && angle <= 270)
            {
                if (transform.localscale.y > 0)
                {
                    flip();
                }

            }
            else
            {
                if (transform.localscale.y < 0)
                {
                    flip();
                }
            }*/
        }
        transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        
    }
    void Flip()
    {
        FaceRight = !FaceRight;
        Vector3 A = transform.localScale;
        A.y *= -1;
      
        transform.localScale = A;
       
    }
}
