using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float AdditionalDeg = 0;
   
    void Start()
    {
       
    }

   
    void Update()
    {
       

    }
    private void FixedUpdate()
    {

        
        Vector3 Dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        // print(Dir.y + " " + Dir.x);
        float Angle = 0;
        if (transform.parent.transform.localScale.x > 0) 
        { 
            Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;
            if (Mathf.Abs(Angle) >= 90 && Mathf.Abs(Angle) <= 180)
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
            }
        }
        else
        {
             Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg + 180;

            if (Angle >= 90 && Angle <= 270)
            {
                if (transform.localScale.y > 0 )
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
            }
        }
        transform.rotation = Quaternion.AngleAxis(Angle  , Vector3.forward);
        
    }
    void Flip() 
    {
        Vector3 A = transform.localScale;
        A.y *= -1;
        transform.localScale = A;
    }
}
