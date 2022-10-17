using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public Transform BossNextDoor;
    LineRenderer Line;
    public float delay = 0f;
    void Start()
    {
        BossNextDoor = GameObject.Find("VRot").GetComponent<Transform>();
        Line = GetComponent<LineRenderer>();
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    // Update is called once per frame
    void Update()
    {
        Line.SetPosition(0, BossNextDoor.position);
        Line.SetPosition(1, transform.position);
        float distance = Mathf.Sqrt(Mathf.Pow(BossNextDoor.position.y - transform.position.y, 2) + Mathf.Pow(transform.position.x - BossNextDoor.position.x, 2));
        RaycastHit2D hit = new RaycastHit2D();
        hit = Physics2D.Raycast(transform.position, BossNextDoor.position - transform.position, distance);
        if (hit.collider.gameObject.GetComponent<Player1>() != null) hit.collider.gameObject.GetComponent<Player1>().Takehit(3);
    }
}
