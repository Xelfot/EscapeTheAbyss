using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public GameObject vv;

    private void Start()
    {
        Instantiate(vv, transform.position, Quaternion.identity);
    }
}
