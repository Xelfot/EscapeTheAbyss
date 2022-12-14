using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wall;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
	    {
            Instantiate(wall, transform.GetChild(0).position, Quaternion.identity);
            Instantiate(wall, transform.GetChild(1).position, Quaternion.identity);
            Instantiate(wall, transform.GetChild(2).position, Quaternion.identity);
            Destroy(gameObject);
     	}
    }
    
}
