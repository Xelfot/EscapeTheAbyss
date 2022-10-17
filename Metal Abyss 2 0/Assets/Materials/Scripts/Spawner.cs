using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] vvVariants;

    private float timeBtwSpawn;
    public float starttimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    

   
   private void Update()
    {
        Debug.Log(Vector3.Distance(GameObject.Find("Player20").transform.position, GameObject.Find("Sprite-0003 3").transform.position));
        if (timeBtwSpawn <= 0 && Vector3.Distance(GameObject.Find("Player20").transform.position, GameObject.Find("Sprite-0003 3").transform.position) > 50f)
        {
            int rand = Random.Range(0, vvVariants.Length);
            Instantiate(vvVariants[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = starttimeBtwSpawn;
            if (starttimeBtwSpawn > minTime)
            {
                starttimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
