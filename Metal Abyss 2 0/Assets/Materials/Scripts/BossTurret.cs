using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret : MonoBehaviour
{

    public float Range;
    float startDelay;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float delay;
    [SerializeField] private float AdditionalDeg;
    private Boss boss;
    private GameObject Player;
    void Start()
    {
        startDelay = delay;
        Player = GameObject.Find("Player20").gameObject;
        boss = GetComponentInParent<Boss>();
    }

    private void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
        else Shoot();
    }


    private void Shoot()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) <= Range)
        {
            Vector3 Dir = Camera.main.WorldToScreenPoint(Player.transform.position) - Camera.main.WorldToScreenPoint(transform.position);
            float Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + AdditionalDeg;

            Instantiate(Bullet, transform.position, Quaternion.AngleAxis(Angle, Vector3.forward));
            delay = startDelay;
        }
    }

    internal void TakeHit(int v)
    {
        boss.TakeHit(v);
    }
}
