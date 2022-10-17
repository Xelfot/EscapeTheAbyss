using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float AdditionalDeg = 0;
    [SerializeField] private float lifeTime = 10;
    [SerializeField] private float Speed = 5;
    
    //public GameObject trigger;

    GameObject Player;
    public int collisionDamage;
    public string collisionTag;
    void Start()
    {
        /*Player = GameObject.Find("Player20").gameObject;
        Vector3 Dir = Camera.main.WorldToScreenPoint(Player.transform.position) - Camera.main.WorldToScreenPoint(transform.position);
        float Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;
        transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);*/
        StartCoroutine(life());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Boss>()) collision.gameObject.GetComponent<Boss>().TakeHit(1);
        if (collision.gameObject.GetComponent<BossTurret>()) collision.gameObject.GetComponent<BossTurret>().TakeHit(1);
        print($"OnTriggerEnter {collision.gameObject.tag}");
        if ((collision.gameObject.tag =="Enemy"))
        {
            collision.GetComponent<EnemyHP>().TakeDamage(collisionDamage);
        }
        if (collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
        }
       
        if (collision.gameObject.tag == "Player" )
        {
            Player1 hp = collision.gameObject.GetComponent<Player1>();
            hp.Takehit(collisionDamage);
           
        }
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        transform.position = transform.position + transform.right * Speed * Time.deltaTime;
        //transform.position = Vector3.forward;
    }
    IEnumerator life()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

}
